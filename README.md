# Upload Files Sample App

This sample app demonstrates concepts described in the [Upload files in ASP.NET Core](https://docs.microsoft.com/aspnet/core/mvc/models/file-uploads) topic.

## Security considerations

Use caution when providing users with the ability to upload files to a server. Attackers may execute [denial of service](/windows-hardware/drivers/ifs/denial-of-service) attacks, attempt to upload viruses or malware, and attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Upload files to a dedicated file upload area on the system, preferably a non-system drive. Use of a dedicated location makes it easier to impose security measures on uploaded content. Disable execute permissions on the file upload location.&dagger;
* Never persist uploaded files in the same directory tree as the app.&dagger;
* Use a safe file name determined by the app, not directly from user input or the untrusted file name of the uploaded file.&dagger;
* Only allow a specific set of approved file extensions.&dagger;
* Check the file format signature to prevent a user from uploading a masqueraded file (for example, uploading an *.exe* file with a *.txt* extension).&dagger;
* Verify that client-side checks are also performed on the server. Client-side checks are easy to circumvent.&dagger;
* Check the size of the upload and prevent larger uploads than expected.&dagger;
* When files shouldn't be overwritten by an uploaded file with the same name, check the file name against the database or physical storage before uploading the file.
* **Run a virus/malware scanner on uploaded content before the file is stored.**

&dagger;The sample app demonstrates an approach that meets the criteria.

> [!WARNING]
> Uploading malicious code to a system is frequently the first step to executing code that can:
>
> * Completely takeover a system.
> * Overload a system with the result that the system crashes.
> * Compromise user or system data.
> * Apply graffiti to a public UI.
>
> For information on reducing the attack surface area when accepting files from users, see the following resources:
>
> * [Unrestricted File Upload](https://www.owasp.org/index.php/Unrestricted_File_Upload)
> * [Azure Security: Ensure appropriate controls are in place when accepting files from users](/azure/security/azure-security-threat-modeling-tool-input-validation#controls-users)

## How to use the sample

1. In the *appsettings.json* file:

   1. Set the connection string for a database where you intend to store uploaded file content. Confirm that execute permissions are disabled for all users at that location.
   1. Set the path for stored files.
   1. Set the file size limit.

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