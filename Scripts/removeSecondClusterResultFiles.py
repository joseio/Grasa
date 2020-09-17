import io
import sys
import os
import re
from shutil import copy

def main():
	topDir = os.getcwd()
	for PSEScoreFolders in os.listdir(topDir):
		print('Working in ' + PSEScoreFolders)
		if PSEScoreFolders == "1" or PSEScoreFolders == "NaN" or ".py" in PSEScoreFolders:
			continue
		else:
			print('print current dir = ' + os.getcwd())
			os.chdir(os.path.join(topDir, PSEScoreFolders)) #Change directory of PSE folders
			insidePSEScoreFolder = os.getcwd()
			
			#Get all subdirectories in current folder
			for submissionFile in os.listdir(insidePSEScoreFolder): #ERROR: on this line... I change to reportparserlearning so I cant see all submission files on new iteration!!!
				if "SecondClusterResults" in submissionFile:
					os.remove(submissionFile)

                    

if __name__ == '__main__':
    main()