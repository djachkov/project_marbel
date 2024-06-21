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

## Using branches

By default, you will checkout the `main` branch.
This branch is protected from direct changes, so in order to save your work you have to switch branch.
First, be sure you pull the latest remote changes:
```
git pull --rebase
```

That command will get the latest changes for the branch you're in (by default, `main`).
Then, create a new branch:
```
git checkout -b dev/{your_name} # For example, dev/dmitrii
```

Change `{your_name}` to your actual name, or to any other unique identifier. 
You can have one `dev` branch for every changes, or you can create a new one for every new feature. 

Then you can work on the changes you want to add.
After finished, save your Unity project. You will see git detected new changes by using command:

```
git status
```

Example output:

```
On branch development
Your branch is up to date with 'origin/development'.

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git restore <file>..." to discard changes in working directory)
        modified:   ProjectMarbel/Assets/Scenes/TestScene.unity
        modified:   README.md

no changes added to commit (use "git add" and/or "git commit -a")
```

With that, you have to save this changes to `git` as a `commit` and then push it to remote server. 
First, you have to prepare changes for saving by adding them to `commit` (or in git terminology - stage it):
```
git add {file1} {file2} {file3}
```
Change `{file1}` and so on on the actual filenames
> You can use TAB to substitute the filename after start typing it

Alternatively, you can use
```
git add .
```
To add all changes at once, but be sure there is nothing you **don't** want to add.

When files are staged, you can save a commit:

```
git commit -m "{Your commit message}"
```

Please, write meaningful commit messages for the proper dev history and for others to understand what the change is. 

For pushing the commit, you can use:

```
git push
```

> NOTE: first time after branch created you should set the tracking of it. Just use `git push` and in the error message `git` will print what command you should use for that.

When changes are pushed to your branch, you can access it in the web version. 
To add your changes to the `main`  branch, you should create a `Pull request`  in UI. 
