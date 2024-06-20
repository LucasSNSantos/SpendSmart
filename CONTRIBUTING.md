# Getting started

## Compiling Server

Prerequisites:
- .NET 8.0 SDK

To compile the server, open .sln with Visual Studio or use CLI SDK of dotnet do compile.

## Compiling Client

Prerequisites:
- Node.js installed

To compile the cliente, execute the command "npm run dev".

# Connecting to Firestore

Prerequisites
- Google Cloud Account: You need a Google Cloud account to access Firestore.

Log in into your Google Cloud Console account and create a new project. Within this project, create a Firestore database, you can use the free tier version.

In order to connect your project to Firestore, you must Set up an Application Default Credential in your machine

Install gcloud CLI:
https://cloud.google.com/sdk/docs/install

ADC Authentication:
https://cloud.google.com/docs/authentication/provide-credentials-adc

Once you have Installed and initialized, if you follow the instruction you will end up running:

`gcloud auth application-default login`

That command will create the json configuration file:

- Linux, macOS: `$HOME/.config/gcloud/application_default_credentials.json`
- Windows: `%APPDATA%\gcloud\application_default_credentials.json`

Set your application default credentials in your environment:

- Windows Command Prompt: `set GOOGLE_APPLICATION_CREDENTIALS=KEY_PATH`
- Windows PoerShell: `$env:GOOGLE_APPLICATION_CREDENTIALS="KEY_PATH"`
- Linux/MacOs: `export GOOGLE_APPLICATION_CREDENTIALS="KEY_PATH"`

Set your project id in your environment:

- Windows Command Prompt: `set GOOGLE_CLOUD_PROJECT_ID=your-google-cloud-project-id`
- Windows PowerShell: `$env:GOOGLE_CLOUD_PROJECT_ID="your-google-cloud-project-id"`
- Linux/MacOs: `export GOOGLE_CLOUD_PROJECT_ID=your-google-cloud-project-id`

For the last but not less important, you need to set a secret in your application for the project id.

Right click on your solution then Manage User Secrets

![image](https://github.com/LucasSNSantos/SpendSmart/assets/32469468/cda75cca-0167-4136-888d-2aa382a4efb6)

After that add the following setting replacing the value with your projectId set on firestore:

```json
{
  "GoogleCloud": {
    "ProjectId": "<gcloud-project-id>"
  }
}
```

That should be enough to start working.

## Troubleshooting

### Windows

**Problem:**

Can't execute `gcloud auth application-default login` error is preventing me to run it.

**Solution:**

You probably need to execute `Set-ExecutionPolicy Unrestricted` to remove restriction in executing third party code.

# How to submit changes

### 1. Fork
First of all, make a fork of this project, work always on the fork and submit pull requests.

### 2. Find an issue to work on
Look for an open issue, if there are none available, think of something you would like to work on and propose it in a clear and organized way.

### 3. Get the issue in charge
If the issue has no one assigned to it and you wish to work on it, ask first if you can work on it and then start working.

### 4. Create a branch
Create a branch in your forked repository to work on your issue

### 5. Commit your work
Commit your changes in your branch.

### 6. Pull Request
Once you think you're good to go, submit a Pull Request assigned the issue you are working on. Wait for the reviews to be done, if everything is okay then it will be merged into main, otherwise fix what need to be fixed and just commit the changes on the branch you did the pull request.

Don't forget to assign your issue on the PR.

### 7. Submitting
Add relevant information about your solution, if needed also some screenshots would be great.
