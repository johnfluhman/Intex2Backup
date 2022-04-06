using System;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace CollisionsDB.Models
{
    public class HousingData
    {
        public float MILEPOINT { get; set; }
        public float LAT_UTM_Y { get; set; }
        public float LONG_UTM_X { get; set; }
        public float PEDESTRIAN_INVOLVED { get; set; }
        public float BICYCLIST_INVOLVED { get; set; }
        public float MOTORCYCLE_INVOLVED { get; set; }
        public float OVERTURN_ROLLOVER { get; set; }
        public float TEENAGE_DRIVER_INVOLVED { get; set; }
        public float NIGHT_DARK_CONDITION { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                MILEPOINT, LAT_UTM_Y, LONG_UTM_X, PEDESTRIAN_INVOLVED, BICYCLIST_INVOLVED, MOTORCYCLE_INVOLVED,OVERTURN_ROLLOVER,TEENAGE_DRIVER_INVOLVED,NIGHT_DARK_CONDITION
            };
            int[] dimensions = new int[] { 1, 8 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
