using CoreAudio;

namespace VuServer
{
    public class CoreAudioService : BackgroundService
    {
        public float DbValueLeft
        {
            get { return _dbValueLeft; }
        }
        public float DbValueRight
        {
            get { return _dbValueRight; }
        }

        private volatile float _dbValueRight;
        private volatile float _dbValueLeft;

        private const int Interval = 10;

        private const int Samples = 10;


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var contextId = Guid.NewGuid();

            var deviceEnumerator = new MMDeviceEnumerator(contextId);
            var audioDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            var samplesLeft = new double[Samples];
            var samplesRight = new double[Samples];
            var samplePos = 0;
            double sampleVal = 0;

            while (!stoppingToken.IsCancellationRequested) 
            {
                sampleVal = audioDevice.AudioMeterInformation?.PeakValues[0] * 100 ?? 0;
                samplesLeft[samplePos] = sampleVal;

                sampleVal = audioDevice.AudioMeterInformation?.PeakValues[1] * 100 ?? 0;
                samplesRight[samplePos] = sampleVal;

                _dbValueLeft = (float)samplesLeft.Average();
                _dbValueRight = (float)samplesRight.Average();


                samplePos++;
                if (samplePos >= Samples)
                    samplePos = 0;

                await Task.Delay(5, stoppingToken);

            }



        }
    }
}
