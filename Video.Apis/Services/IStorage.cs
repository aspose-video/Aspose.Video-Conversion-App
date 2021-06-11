﻿using Video.Apis.Api.Models;
using Video.Apis.Models.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Video.Apis.Services
{
    public interface IStorage
    {
        string SourceRoot();
        string ExportRoot();
        string ReportRoot();
        Task UploadFileListAsync(Dictionary<string, Stream> documents);
        Task<string> UploadFileAsync(string filePath, Stream fileStream);
        Task<Stream> DownloadFileAsync(string filePath);
        Task CopyFolderAsync(string sourceFolder, string targetFolder);

    }
}