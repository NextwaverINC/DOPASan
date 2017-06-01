using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using AForge;
using AForge.Math;
using AForge.Controls;
using AForge.Imaging;
using AForge.Imaging.Formats;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DOPAScan
{
    public class WebCameraUtil
    {
        public static FilterInfoCollection WebCameraDeviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        public static VideoCaptureDevice GetWebCameraSource(Int32 WebCameraDeviceIndex)
        {
            VideoCaptureDevice WebCameraSource = new VideoCaptureDevice(WebCameraDeviceList[WebCameraDeviceIndex].MonikerString);

            return WebCameraSource;
        }

        public static void ConnectWebCamera(ref VideoCaptureDevice WebCameraSource)
        {
            //if (WebCameraSource != null && WebCameraSource.IsRunning == false)
            //{
                WebCameraSource.VideoResolution = WebCameraSource.VideoCapabilities[WebCameraSource.VideoCapabilities.Length - 1];

                WebCameraSource.Start();
            //}
        }

        public static void DisConnectWebCamera(ref VideoCaptureDevice WebCameraSource)
        {
            if (WebCameraSource != null && WebCameraSource.IsRunning == true)
            {
                WebCameraSource.SignalToStop();
                WebCameraSource.WaitForStop();
                WebCameraSource = null;
                GC.Collect();
            }
        }

        public static Bitmap GetNewFrameImage(ref NewFrameEventArgs EventArgs)
        {
            Bitmap WebCameraFrameImage = (Bitmap)EventArgs.Frame.Clone();
            return WebCameraFrameImage;
        }
    }
}
