using System;
using System.Collections.Generic;
using System.Text;

namespace FFmpeg.NET.Enums
{
    public enum VideoCodecTune
    {
        Default,
        film,
        animation,
        grain,
        stillimage,
        fastdecode,
        zerolatency,
        psnr,
        ssim
    }
}
