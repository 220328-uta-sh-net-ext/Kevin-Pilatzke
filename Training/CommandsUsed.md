List of Commands used for Git
=====================================
clear : clear all data on screen of current bash
$BASH_VERSION : Current version
pwd (Print working directory): current location file/folder
cd : change location (Change directory)
	-Start name and hit tab to auto complete
	-if folder has space, use example : \program\ info/
	-cd .. : go back a folder
	-cd ~ :go back to original bash start location
mkdir “insert name” : add new folder at current location
rmdir “insert name” : remove folder with that name in current location
ls : lists all files/folders of current location
	ls -1: more info* (List is made one file per line)
	ls 2107* : list using meta-characters?
touch : create a file (Name of file . Type of file)
rm “name” : remove file
“insert application” “name of file” : open file in a specific program
	-If no file exists, will ask if you want to create file
git status: checks data locally to that of the version on github
		-Modified: file is changed
git add “file name” : adding changes to the “staging” area locally
git commit -m “add note” : A finalized version of changes locally(-m adds  a message to the version)
git push: all changes that were committed gets pushed to the server
git pull: changes that happened from server will be add locally
git log : the Commit history log information
	-git log - - oneline : simplifies the commit history to one line
	-git log - - pretty=oneline : simplifies the commit history and easier to read. 

Git Workflow
	-Origin/Server
		-Main/Master : Main version of the data/code (Live – Users for access)
		-Branches : To work on the code/ features / etc
			-Can do a pull request to look over before merging

git branch –help : will open explorer with help information
git branch -a : will show all branches, shows what branch you are on
git branch “add name” : will create branch locally
git checkout “insert name” : go to the specific branch
git checkout -b “insert name” : Creates and changes to that branch
git branch -m “insert new name” : Changes the name of current branch
git branch : show local branches available
git branch -d “insert name of branch” : delete said branch (Safe delete: Git prevents from deleting if it 							has un-merged changes)
git branch -D “insert name of branch” : deletes branch (Permanent delete: Deletes all within branch 							without Git preventing delete, deletes all commits 								associated of line of development)