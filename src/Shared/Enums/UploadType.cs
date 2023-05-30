using System.ComponentModel;

namespace Grs.BioRestock.Shared.Enums
{
    public enum UploadType : byte
    {
        

        [Description(@"Images\ProfilePictures")]
        ProfilePicture,

        [Description(@"Documents")]
        Document
    }
}