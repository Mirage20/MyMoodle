using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyMoodle
{
    class BinarySerializeProvider
    {
        public static string FilePath { get; set; }
        public static void save(MoodleSettings settingsObj)
        {

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, settingsObj);
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(null,"Error while saving data.","My Moodle",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public static MoodleSettings load()
        {
            
            try
            {
                if (File.Exists(FilePath))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    MoodleSettings moodleObj;
                    try
                    {
                       moodleObj = (MoodleSettings)formatter.Deserialize(stream);
                       stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        File.Delete(FilePath);
                        moodleObj= load();
                        
                    }
                    
                    
                    return moodleObj;
                }
                else
                {
                    MoodleSettings tmp = new MoodleSettings();
                    save(tmp);
                    return load();
                }
            }
            catch (Exception)
            {
                
                
            }
            return new MoodleSettings();
        }

        
    }
}
