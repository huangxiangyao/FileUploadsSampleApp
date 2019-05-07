# Upload Files Sample App

This sample app demonstrates concepts described in the [Upload files in ASP.NET Core](https://docs.microsoft.com/aspnet/core/mvc/models/file-uploads) topic.

## Security considerations

Caution must be taken when providing users with the ability to upload files to a server. Attackers may execute [denial of service](/windows-hardware/drivers/ifs/denial-of-service), upload viruses or malware, and perform other attacks on a system. Some security steps that reduce the likelihood of a successful attack are:

* Upload files to a dedicated file upload area on the system. Use of a dedicated location makes it easier to impose security measures on uploaded content. Disable execute permissions on the file upload location.
* Use a safe file name determined by the app, not from user input or the file name of the uploaded file.
* Only allow a specific set of approved file extensions.
* Verify client-side checks are performed on the server. Client-side checks are easy to circumvent.
* Check the size of the upload and prevent larger uploads than expected.
* **Run a virus/malware scanner on uploaded content.**

> [!WARNING]
> Uploading malicious code to a system is frequently the first step to executing code that can:
> * Completely takeover a system.
> * Overload a system with the result that the system crashes.
> * Compromise user or system data.
> * Apply graffiti to a public UI.

## How to use the sample

1. In the *appsettings.json* file:

   1. Set the connection string for a database where you intend to store uploaded file content. Confirm that execute permissions are disabled for all users at that location.
   1. Set the path for stored files.

1. Perform an initial migration on the database:

   # [Visual Studio](#tab/visual-studio)

   1. Open the Package Manager Console (PMC) **Tools** > **NuGet Package Manager** > **Package Manager Console**.

   1. In the PMC, execute the following commands:

      ```PowerShell
      Add-Migration Initial
      Update-Database
      ```

   # [Visual Studio Code / Visual Studio for Mac / .NET Core CLI](#tab/visual-studio-code+visual-studio-mac+netcore-cli)

   From a command shell opened to the project's folder, execute the following commands:

   ```console
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

   ---