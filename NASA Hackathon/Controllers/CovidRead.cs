using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_Hackathon.Controllers
{
    public abstract class CovidRead
    {
        protected Bitmap paperImage;
        protected List<double> Data;
        public Bitmap PaperImage
        {
            get
            {
                return this.paperImage;
            }
        }

        public CovidRead(Bitmap paperImage)
        {
            this.paperImage = paperImage;
            GetPaperData(paperImage);
        }
        private void GetPaperData(Bitmap Image)  //ROI影像轉光譜
        {
            List<double> Data = new List<double>();
            for (int i = 0; i < Image.Width; i++)
            {
                int gray_sum = 0;
                for (int t = 0; t < Image.Height; t++)
                {
                    Color P = Image.GetPixel(i, t);
                    int Gray = (P.R * 313524 + P.G * 615514 + P.B * 119538) >> 20;
                    gray_sum += Gray;
                }
                Data.Add(255 - (gray_sum / Image.Height));
            }
            this.Data = Data;
        }
    }

    class PaperAnalysis : CovidRead
    {
        protected List<double> peakIntensity = new List<double>();
        private List<int> peakIndex;
        private List<double> _signalRemoveBaseLine = new List<double>();
        private int lag = 5;
        private double threshold = 5.0;
        private double influence = 0.0;
        private int firstStarIndex = 0;
        private FindBase findBase;
        public List<double> PeakIntensity
        {
            get
            {
                return this.peakIntensity;
            }
        }
        public List<int> PeakIndex
        {
            get
            {
                return this.peakIndex;
            }
        }
        public PaperAnalysis(Bitmap paperImage, int lag, double threshold, double influence) : base(paperImage)
        {
            this.lag = lag; this.threshold = threshold; this.influence = influence;
            this.findBase = new FindBase();
            this.findBase = ZScore.StartAlgo(this.Data, this.lag, this.threshold, this.influence);
            signalRemoveBaseLine();
            FindPeak();
            PeakFilter();
        }
        public PaperAnalysis(Bitmap paperImage) : base(paperImage)
        {
            this.findBase = new FindBase();
            this.findBase = ZScore.StartAlgo(this.Data, this.lag, this.threshold, this.influence);
            signalRemoveBaseLine();
            FindPeak();
            PeakFilter();
        }
        private void signalRemoveBaseLine()
        {
            for (int i = 0; i < this.Data.Count; i++)
            {
                if (i < this.lag || this.Data[i] - this.findBase.avgFilter[i] < 0)
                { _signalRemoveBaseLine.Add(0); }
                else
                { _signalRemoveBaseLine.Add(this.Data[i] - this.findBase.avgFilter[i]); }
            }
        }
        private void FindPeak()
        {
            int startIndex = 0;
            int endIndex = 0;
            List<int> peakIndex = new List<int>();
            int PeakArea = 1;
            bool end = false;

            while (!end)
            {
                if (PeakArea != 1)
                {
                    for (int i = endIndex; i < findBase.signals.Count; i++)
                    {
                        if (findBase.signals[i] == 1)
                        {
                            startIndex = i;
                            break;
                        }
                        else if (i == findBase.signals.Count - 1)
                        {
                            end = true;
                            break;
                        }
                    }
                    if (end)
                    { break; }
                    else
                    {
                        for (int i = startIndex; i < findBase.signals.Count; i++)
                        {
                            if (findBase.signals[i] != 1)
                            {
                                endIndex = i;
                                break;
                            }
                        }
                        if (endIndex <= startIndex) break;
                        double max = 0;
                        int maxIndex = 0;
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            if (this._signalRemoveBaseLine[i] > max)
                            {
                                max = this._signalRemoveBaseLine[i];
                                maxIndex = i;
                            }
                        }
                        peakIndex.Add(maxIndex);
                        PeakArea++;
                    }

                }
                else
                {
                    for (int i = 0; i < findBase.signals.Count; i++)
                    {
                        if (findBase.signals[i] == 1)
                        {
                            startIndex = i;
                            if (firstStarIndex == 0) firstStarIndex = i;
                            break;
                        }
                        else if (i == findBase.signals.Count - 1)
                        {
                            end = true;
                            break;
                        }
                    }
                    if (end)
                    { break; }
                    else
                    {
                        for (int i = startIndex; i < findBase.signals.Count; i++)
                        {
                            if (findBase.signals[i] != 1)
                            {
                                endIndex = i;
                                break;
                            }
                        }
                        double max = 0;
                        int maxIndex = 0;
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            if (this._signalRemoveBaseLine[i] > max)
                            {
                                max = this._signalRemoveBaseLine[i];
                                maxIndex = i;
                            }
                        }
                        peakIndex.Add(maxIndex);
                        PeakArea++;
                    }
                }

            }
            for (int i = 0; i < peakIndex.Count; i++)
            {
                this.peakIntensity.Add(this._signalRemoveBaseLine[peakIndex[i]]);
            }
            this.peakIndex = peakIndex;
        }
        private void PeakFilter()
        {
            List<int> removeIndex = new List<int>();
            int count = 0;
            foreach (int index in this.peakIndex)
            {
                if (count == 0) { count++; continue; }
                if (index < this.firstStarIndex + 20)
                {
                    removeIndex.Add(count);
                    count++;
                }
            }
            for (int i = 0; i < removeIndex.Count; i++)
            {
                this.peakIntensity.RemoveAt(removeIndex[i]);
                this.peakIndex.RemoveAt(removeIndex[i]);
            }
        }
        public DataForPlot GetDataForPlot()
        {
            DataForPlot dataForPlot = new DataForPlot();
            dataForPlot.Signal = this._signalRemoveBaseLine;
            dataForPlot.PeakIndex = this.peakIndex;
            List<int> x = new List<int>();
            for (int i = 0; i < this._signalRemoveBaseLine.Count; i++)
            {
                x.Add(i);
            }
            dataForPlot.X = x;
            return dataForPlot;
        }
    }
    class DataForPlot
    {
        private List<int> x;
        private List<double> signal;
        private List<int> peakIndex;
        public List<int> X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public List<double> Signal
        {
            get { return this.signal; }
            set { this.signal = value; }
        }

        public List<int> PeakIndex
        {
            get { return this.peakIndex; }
            set { this.peakIndex = value; }
        }
    }
    interface GetRisk { double RiskCaculate(); }
    interface GetConcentration { double CaculateConcentration(double PeakIntensity); }
    class Antibody : PaperAnalysis, GetRisk, GetConcentration
    {
        private double antibodyNumber;
        public double AntibodyNumber
        {
            get { return antibodyNumber; }
        }
        public Antibody(Bitmap paperImage, int lag, double threshold, double influence) : base(paperImage, lag, threshold, influence)
        {
        }
        public Antibody(Bitmap paperImage) : base(paperImage)
        {
        }
        private void CacularAntibodyNumber()
        {

        }
        public double RiskCaculate()
        {
            throw new NotImplementedException();
        }

        public double CaculateConcentration(double PeakIntensity)
        {
            return -0.15 * Math.Pow(PeakIntensity, 2) + 30.158 * PeakIntensity + 27.85;
        }
    }
}
