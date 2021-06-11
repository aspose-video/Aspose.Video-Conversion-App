using Video.Apis.Services;
using FFmpeg.NET;
using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Apis.Models.App
{
    public class ConvertParam
    {
        private static Dictionary<string, string> VEDIO_SIZE_ABBR = new Dictionary<string, string>
        {
            { "720x480", "ntsc" },
            { "720x576", "pal" },
            //{ "352x240", "qntsc" },
            //{ "352x288", "qpal" },
            //{ "640x480", "sntsc" },
            { "768x576", "spal" },
            { "352x240", "film" },
            { "128x96", "sqcif" },
            { "176x144", "qcif" },
            { "352x288", "cif" },
            { "704x576", "_4cif" },
            { "1408x1152", "_16cif" },
            { "160x120", "qqvga" },
            { "320x240", "qvga" },
            { "640x480", "vga" },
            { "800x600", "svga" },
            { "1024x768", "xga" },
            { "1600x1200", "uxga" },
            { "2048x1536", "qxga" },
            { "1280x1024", "sxga" },
            { "2560x2048", "qsxga" },
            { "5120x4096", "hsxga" },
            //{ "852x480", "wvga" },
            { "1366x768", "wxga" },
            { "1600x1024", "wsxga" },
            { "1920x1200", "wuxga" },
            { "2560x1600", "woxga" },
            { "3200x2048", "wqsxga" },
            { "3840x2400", "wquxga" },
            { "6400x4096", "whsxga" },
            { "7680x4800", "whuxga" },
            { "320x200", "cga" },
            { "640x350", "ega" },
            { "852x480", "hd480" },
            { "1280x720", "hd720" },
            { "1920x1080", "hd1080" },
            { "2048x1080", "_2k" },
            { "1998x1080", "_2kflat" },
            { "2048x858", "_2kscope" },
            { "4096x2160", "_4k" },
            { "3996x2160", "_4kflat" },
            { "4096x1716", "_4kscope" },
            { "640x360", "nhd" },
            { "240x160", "hqvga" },
            { "400x240", "wqvga" },
            { "432x240", "fwqvga" },
            { "480x320", "hvga" },
            { "960x540", "qhd" },
            //{ "2048x1080", "2kdci" },
            //{ "4096x2160", "4kdci" },
            { "3840x2160", "uhd2160" },
            { "7680x4320", "uhd4320" }
        };
        public string AdjustVolumn { get; set; }
        public string AudioCodec { get; set; }

        public string AudioFormat { get; set; }
        public string AudioBitRate { get; set; }

        public string AudioQuality { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string VideoCodec { get; set; }
        public string VideoSize { get; set; }
        public string VideoCustomWidth { get; set; }
        public string VideoCustomHight { get; set; }
        public string VideoAspectRatio { get; set; }
        public string VideoFps { get; set; }
        public string VideoCRF { get; set; }
        public string VideoCodecPreset { get; set; }
        public string VideoCodecProfile { get; set; }
        public string VideoCodecTune { get; set; }

        public string VideoFormat { get; set; }

        public ConversionOptions ToConversionOptions()
        {
            ConversionOptions ret = new ConversionOptions();
            if (!string.IsNullOrEmpty(AudioCodec))
            {
                if (AudioCodec.EndsWith("none"))
                {
                    ret.RemoveAudio = true;
                }
                else
                {
                    ret.AudioCodec = ConstantsService.GetAudioCodec(AudioCodec);
                } 
            }

            if (!ret.RemoveAudio)
            {
                if (!string.IsNullOrEmpty(AdjustVolumn))
                {
                    try
                    {
                        ret.AdjustVolumn = Int32.Parse(AdjustVolumn);
                    }
                    catch
                    {

                    }
                }
                if (!string.IsNullOrEmpty(AudioQuality))
                {
                    try
                    {
                        ret.AudioQuality = Int32.Parse(AudioQuality);
                    }
                    catch
                    {

                    }
                }
                if (!string.IsNullOrEmpty(AudioBitRate))
                {
                    try
                    {
                        ret.AudioBitRate = Int32.Parse(AudioBitRate);
                    }
                    catch
                    {

                    }
                }
            }

            if(!string.IsNullOrEmpty(StartTime))
            {
                try
                {
                    int seconds = this.GetSecondsFromTimeString(StartTime);
                    ret.Seek = TimeSpan.FromSeconds(seconds);
                }
                catch(Exception)
                {

                }
            }
            if(!string.IsNullOrEmpty(EndTime))
            {
                try
                {
                    int duration = this.GetSecondsFromTimeString(EndTime);

                    if(ret.Seek.HasValue)
                    {
                        duration -= (int)ret.Seek.Value.TotalSeconds;
                    }
                    ret.EndDuration = TimeSpan.FromSeconds(duration);
                }
                catch (Exception)
                {

                }
            }
            if (!string.IsNullOrEmpty(VideoFormat))
            {
                ret.VideoFormat = ConstantsService.GetVideoFormat(VideoFormat);
                ret.OuputExtension = VideoFormat;
            }
            if (!string.IsNullOrEmpty(VideoCodec))
            {
                ret.VideoCodec = ConstantsService.GetVideoCodec(VideoCodec);
            }

            if (!string.IsNullOrEmpty(VideoSize))
            {
                if(VideoSize.Equals("custom") && !string.IsNullOrEmpty(VideoCustomWidth) && !string.IsNullOrEmpty(VideoCustomHight))
                {
                    int width = Int32.Parse(VideoCustomWidth);
                    int height = Int32.Parse(VideoCustomHight);
                    ret.CustomWidth = width;
                    ret.CustomHeight = height;
                    ret.VideoSize = FFmpeg.NET.Enums.VideoSize.Custom;
                }
                else
                {
                    if(VEDIO_SIZE_ABBR.ContainsKey(VideoSize))
                    {
                        ret.VideoSize = ConstantsService.GetVideoSize(VEDIO_SIZE_ABBR[VideoSize]);
                    }
                    else
                    {
                        string[] videoSizeArr = VideoSize.Split('X');
                        if(videoSizeArr.Length == 2)
                        {
                            try
                            {
                                int width = Int32.Parse(videoSizeArr[0]);
                                int height = Int32.Parse(videoSizeArr[1]);
                                ret.CustomWidth = width;
                                ret.CustomHeight = height;
                                ret.VideoSize = FFmpeg.NET.Enums.VideoSize.Custom;
                            }
                            catch(Exception)
                            {

                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(VideoAspectRatio))
            {
                ret.VideoAspectRatio = ConstantsService.GetVideoAspectRatio(VideoAspectRatio);
            }

            if (!string.IsNullOrEmpty(VideoFps))
            {
                try
                {
                    ret.VideoFps = Int32.Parse(VideoFps);
                }
                catch
                {

                }
            }
            if (!string.IsNullOrEmpty(VideoCRF))
            {
                try
                {
                    ret.VideoCRF = Int32.Parse(VideoCRF);
                }
                catch
                {

                }
            }
            if (!string.IsNullOrEmpty(VideoCodecPreset))
            {
                ret.VideoCodecPreset = ConstantsService.GetVideoCodecPreset(VideoCodecPreset);
            }
            if (!string.IsNullOrEmpty(VideoCodecProfile))
            {
                ret.VideoCodecProfile = ConstantsService.GetVideoCodecProfile(VideoCodecProfile);
            }
            if (!string.IsNullOrEmpty(VideoCodecTune))
            {
                ret.VideoCodecTune = ConstantsService.GetVideoCodecTune(VideoCodecTune);
            }
            return ret;
        }

        private int GetSecondsFromTimeString(string timeStr)
        {
            string[] timeArr = timeStr.Split(':');
            int hour = int.Parse(timeArr[0]);
            int minute = int.Parse(timeArr[1]);
            int second = int.Parse(timeArr[2]);
            return hour * 60 * 60 + minute * 60 + second;
        }
    }
}
