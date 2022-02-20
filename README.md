# DownloadWebRecursively
Description: This is to recursively traverse and download Website(given website) and save it to disk. 
              While keeping the online file structure, show download progress in the console. 
Pre-requisite:
              Make sure to have very good Internet connection.
              You should be able to run this program in any IDE(Ex: Visual Studio) which supports console application.
              Make sure to have "D" drive in the local machine where this program is executing. 
              If there is no "D" drive, Please redirect to the file in the source code => WebResource.resx and update value of the variable "LocalDirectory" to the available drive.
Stories List:
              Recursively traverse the Website
              Download all the links
              Save all files to local disk
              Show Progress bar for each file download              
Design:       
              Create target default folder where we want to save the downloaded files
              Using HtmlAgilityPack load the given WebUrl
              Extract all the links using regex.
              For each link, create a file in the target directory and download the file.
              Here I have used WebClient to download the file using the API DownloadFileAsync.
              I have used WebClient here. Because the requirement is to only retrieve file from WebSite and not to Post any information
              DownloadFileAsync => It downloads to a local file resource with the specified URI. Also this method does not block the calling thread.
              WebClient exposes an event DownloadProgressChanged, which helps to keep track on the progress of file downloaded. 
              WebClient exposes an event DownloadFileCompleted, which helps to keep track when the file download is completed.
Install/Run :
              Pull the source code from https://github.com/RoopaNShettigar/DownloadWebRecursively.git to local repository.
              Open the solution from Visual Studio 2019 (any IDE which supports console app to run)
              Build the solution and start Execution.
              You can see that console window is opened
              Each file progress should be able to see and it also notify when each file download is completed.
        
