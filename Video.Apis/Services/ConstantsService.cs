using FFmpeg.NET.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Apis.Services
{
    public class ConstantsService
    {
        internal static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = "", str = "";
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
        public static string GenerateUrlFilename()
        {
            return GetRandomString(8, true, true, true, false, "");
        }
        public static AudioCodec GetAudioCodec(string audioCodec)
        {
            AudioCodec ret;
            if (Enum.TryParse(audioCodec, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid audio codec");
            }
        }

        public static AudioFormat GetAudioFormat(string audioFormat)
        {
            AudioFormat ret;
            if (Enum.TryParse(audioFormat, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid audio format");
            }
        }

        static Dictionary<string, string> videoFormatAlias = new Dictionary<string, string>
        {
            { "mkv", "matroska" },
            {"wmv", "asf" }
        };

        public static VideoFormat GetVideoFormat(string videoFormat)
        {
            VideoFormat ret;
            if(videoFormatAlias.ContainsKey(videoFormat))
            {
                videoFormat = videoFormatAlias[videoFormat];
            }
            if (Enum.TryParse(videoFormat, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video format");
            }
        }

        public static VideoCodec GetVideoCodec(string videoCodec)
        {
            VideoCodec ret;
            if (Enum.TryParse(videoCodec, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video codec");
            }
        }

        public static VideoCodecPreset GetVideoCodecPreset(string videoCodecPreset)
        {
            VideoCodecPreset ret;
            if (Enum.TryParse(videoCodecPreset, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video codec preset");
            }
        }

        public static VideoCodecProfile GetVideoCodecProfile(string videoCodecProfile)
        {
            VideoCodecProfile ret;
            if (Enum.TryParse(videoCodecProfile, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video codec profile");
            }
        }

        public static VideoCodecTune GetVideoCodecTune(string videoCodecTune)
        {
            VideoCodecTune ret;
            if (Enum.TryParse(videoCodecTune, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video codec tune");
            }
        }

        public static VideoAspectRatio GetVideoAspectRatio(string videoAspectRatio)
        {
            VideoAspectRatio ret;
            if (Enum.TryParse(videoAspectRatio, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video aspect ratio");
            }
        }

        public static VideoSize GetVideoSize(string videoSize)
        {
            VideoSize ret;
            if (Enum.TryParse(videoSize, out ret))
            {
                return ret;
            }
            else
            {
                throw new Exception("Invalid video size");
            }
        }
    }
}
