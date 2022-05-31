using System;
namespace Construxiv.Base.Models
{
    /// <summary>
    /// Construxiv Base FileId and Reversion of File
    /// </summary>
    public class FileIdRev
    {
        public string BaseFileId { get; set; }
        public int BaseMajorRev { get; set; }
        public int BaseMinorRev { get; set; }
    }

    public class FileIdName
    {
        public string Filename { get; set; }
        public string FileLocation { get; set; }
        public string BaseFileId { get; set; }
        public int BaseMajorRev { get; set; }
        public int BaseMinorRev { get; set; }
    }
    public class ReimportFileModel
    {
        public string ModelFileId { get; set; }
        public string FileLocation { get; set; }
    }
}
