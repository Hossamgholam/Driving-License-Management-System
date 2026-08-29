using DevExpress.Utils.MVVM.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVlD.Global_Class
{
    internal static class ClsUtil
    {
        public static bool IsFolderCreated(string Path)
        {
            if (Directory.Exists(Path))
            {
                return true;
            }
            
            try
            {
             
                Directory.CreateDirectory(Path);
                   
                return true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("The Created folder Erro:"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
            
        }
        public static string GenerateImageNameWithGuid(string sourceImageFill)
        {
            FileInfo info=new FileInfo(sourceImageFill);
            string extention=info.Extension;
            return GenerateGuid() + extention;
            

        }
        public static bool CopyImageToProjectFolder(ref string SourceImageFill)
        {
            string DistinationFolder = @"G:\universial\specialis\programing advice\c#\19 - Full Real Project - DVLD\ProjectImage";
            if (!IsFolderCreated(DistinationFolder))
            {
                return false;
            }
            string NewImageName = GenerateImageNameWithGuid(SourceImageFill);
            string DistinationFill = Path.Combine(DistinationFolder, NewImageName);

            try
            {
                File.Copy(SourceImageFill, DistinationFill, true);
                SourceImageFill=DistinationFill;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy Source Image Error:"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}
