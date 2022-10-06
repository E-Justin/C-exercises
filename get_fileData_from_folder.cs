const string dirName = "FileCollection";
const string fileName = "myResults.txt";

if (File.Exists(fileName))  // if file already exists
{
    File.Delete(fileName);  // delete it to start over
}


if (Directory.Exists(dirName))  // if directory exists
{   
    // counters for number of files
    int docxCounter = 0;
    int pptxCounter = 0;
    int xlsxCounter =0;
    int totalFiles = 0;

    // counters for size in bytes
    long docxBytes = 0;
    long pptxBytes = 0;
    long xlsxBytes = 0;
    long totalBytes = 0;

    List<string> dirContents = new List<string>(Directory.EnumerateFileSystemEntries(dirName));
    //foreach(string file in dirContents)
    DirectoryInfo di = new DirectoryInfo(dirName);

    foreach (FileInfo file in di.EnumerateFiles())  // iterate through each file
    {
        // if file is a word, powerpoint, or excel file
        if (file.Name.EndsWith(".docx") | file.Name.EndsWith(".pptx") | file.Name.EndsWith(".xlsx"))  
        {   if (file.Name.EndsWith(".docx"))  // if word file
            {
                docxCounter++;
                docxBytes += file.Length;
            }
            else if (file.Name.EndsWith(".pptx"))  // if powerpoint file
            {
                pptxCounter ++;
                pptxBytes += file.Length;
            }
            else //(file.EndsWith(".xlsx"))
            {
                xlsxCounter ++;
                xlsxBytes += file.Length;
            }

            // get total files and total size in bytes, one file at a time
            totalFiles ++;
            totalBytes += file.Length;
        }
    }

    // Write data to .txt file
    using(StreamWriter sw = File.CreateText(fileName))  // create new .txt file
    {
        sw.WriteLine("----- Results --------");
        sw.WriteLine($"Total Files : {totalFiles}");
        sw.WriteLine($"Excel Files : {xlsxCounter}");
        sw.WriteLine($"Word  Files : {docxCounter}");
        sw.WriteLine($"Ppt   Files : {pptxCounter}");
        sw.WriteLine(" ");
        sw.WriteLine($"Total Size  : {totalBytes:N}");
        sw.WriteLine($"Excel Size  : {xlsxBytes:N}");
        sw.WriteLine($"Word  Size  : {docxBytes:N}");
        sw.WriteLine($"Ppt   Size  : {pptxBytes:N}");
    }
    
    
}
else  // if directory does not exist
{
    Console.WriteLine("Directory Does not exist");  // let user know
}
