using StateMachineSample.Lib.Common;

namespace StateMachineSample.Lib.Model
{
    public class AirConditioner : NotificationObject
    {
        public const int MaxTargetTemperature = 40;

        public const int MinTargetTemperature = 15;

        public const int MaxHumidity = 90;

        public const int MinHumidity = 20;

#pragma warning disable IDE1006 // 命名スタイル
        private int _Temperature { get; set; }
#pragma warning restore IDE1006 // 命名スタイル

        public int Temperature
        {
            get => _Temperature;
            set
            {
                if (_Temperature != value)
                {
                    _Temperature = value;
                    RaisePropertyChanged(nameof(Temperature));
                }
            }
        }

#pragma warning disable IDE1006 // 命名スタイル
        private int _TargetTemperature { get; set; }
#pragma warning restore IDE1006 // 命名スタイル

        public int TargetTemperature
        {
            get => _TargetTemperature;
            set
            {
                if (_TargetTemperature != value)
                {
                    _TargetTemperature = value;
                    RaisePropertyChanged(nameof(TargetTemperature));
                }
            }
        }

#pragma warning disable IDE1006 // 命名スタイル
        private int _Humidity { get; set; }
#pragma warning restore IDE1006 // 命名スタイル

        public int Humidity
        {
            get => _Humidity;
            set
            {
                if (_Humidity != value)
                {
                    _Humidity = value;
                    RaisePropertyChanged(nameof(Humidity));
                }
            }
        }

        public StainLevel StainLevel { get; private set; }

        private int AnalysisCount { get; set; }

        private int CleanCount { get; set; }

        private StainLevel PrevStainLevel { get; set; }

        private bool AnalysisFinished => StainLevel != StainLevel.Unknown;

        private bool CleanFinished => StainLevel == StainLevel.High && CleanCount >= 20
                                      || StainLevel == StainLevel.Low && CleanCount >= 10;

        public void Initialize()
        {
            Temperature = 30;

            TargetTemperature = MinTargetTemperature;

            Humidity = 50;

            StainLevel = StainLevel.Unknown;

            PrevStainLevel = StainLevel.Unknown;

            AnalysisCount = 0;

            CleanCount = 0;
        }

        public void Start()
        {
            Temperature = 30;

            Humidity = 50;
        }

        public void Stop()
        {
            StainLevel = StainLevel.Unknown;

            PrevStainLevel = StainLevel.Unknown;

            AnalysisCount = 0;

            CleanCount = 0;
        }

        public void Up()
        {
            if (TargetTemperature < MaxTargetTemperature) TargetTemperature++;
        }

        public void Down()
        {
            if (TargetTemperature > MinTargetTemperature) TargetTemperature--;
        }

        public void CoolControl()
        {
            if (TargetTemperature < Temperature) Temperature--;
        }

        public void HeatControl()
        {
            if (TargetTemperature > Temperature) Temperature++;
        }

        public void DryControl()
        {
            if (Humidity > MinHumidity) Humidity--;
        }

        public StainLevel StainLevelAnalysis()
        {
            AnalysisCount++;

            if (AnalysisCount >= 5)
                switch (PrevStainLevel)
                {
                    case StainLevel.Unknown:
                        StainLevel = StainLevel.Low;
                        break;
                    case StainLevel.Low:
                        StainLevel = StainLevel.High;
                        break;
                    case StainLevel.High:
                        StainLevel = StainLevel.Low;
                        break;
                }
            else
                StainLevel = StainLevel.Unknown;

            return StainLevel;
        }

        public bool DeepCleanControl()
        {
            CleanCount++;

            return CleanFinished;
        }

        public bool LightCleanControl()
        {
            CleanCount++;

            return CleanFinished;
        }

        public void CleanEnd()
        {
            PrevStainLevel = StainLevel;

            StainLevel = StainLevel.Unknown;

            AnalysisCount = 0;

            CleanCount = 0;
        }
    }
}