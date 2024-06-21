# Environment installation

## Git

First, you need to install Git for your platform from here:
https://git-scm.com/downloads

>Please, follow the installation guides carefully and change settings only if you know what you're doing. 

## Git LFS

For storing the large files on the GitHub, the extension is needed. 
For Windows, you can install it from here:
https://git-lfs.com/

If you're using other platform, please follow the installation guide:
https://github.com/git-lfs/git-lfs?utm_source=gitlfs_site&utm_medium=installation_link&utm_campaign=gitlfs#installing

## Unity

This project supports Unity 2019.4.40f1 LTS
You can download it using Unity Hub from this page:
https://unity.com/releases/editor/archive

## Setup GitHub access keys

In order to copy the project on your machine, you should create and add to your account SSH access keys. To do that, you can follow this guides: 

1.  Creating a new `ssh` key: https://docs.github.com/en/authentication/connecting-to-github-with-ssh/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent?platform=windows
2. Adding a new key to you account: https://docs.github.com/en/authentication/connecting-to-github-with-ssh/adding-a-new-ssh-key-to-your-github-account?platform=windows

## Cloning repository

After setup of the access keys, you can now access repository locally on your machine using the `git` tool. 
Open the shell (Git Bash on windows or the command line interface of your choice on other platforms) in the directory you want to use for the project, and use following commands:

```
mkdir ProjectMarbel
git clone git@github.com:djachkov/project_marbel.git ProjectMarbel

```

That will create a new directory with the name `ProjectMarbel` and will clone the repository to that folder.

After that, you can select the folder in the **UnityHub** to add an existed project. 