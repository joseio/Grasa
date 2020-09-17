import io
import sys
import os
import re
from shutil import copy

def main():
	topDir = os.getcwd()
	for PSEScoreFolders in os.listdir(topDir):
		print('Working in ' + PSEScoreFolders)
		if PSEScoreFolders == "1" or PSEScoreFolders == "NaN" or PSEScoreFolders == "Passed&FailedTests" or ".py" in PSEScoreFolders:
			continue
		else:
			print('print current dir = ' + os.getcwd())
			os.chdir(os.path.join(topDir, PSEScoreFolders)) #Change directory of PSE folders
			insidePSEScoreFolder = os.getcwd()
			
			#Get all subdirectories in current folder
			for submissionFile in os.listdir(insidePSEScoreFolder): #ERROR: on this line... I change to reportparserlearning so I cant see all submission files on new iteration!!!
				if "SecondClusterResults" in submissionFile:
					clusterResults = list()
					uniqueSubmissions = set()

                    #Read all lines from student's submission (.cs) file
					with io.open(submissionFile, 'r',encoding='utf-8-sig') as f:
						clusterResults = f.read().splitlines()
                    
					for line in clusterResults:
						if line.find("PSE Score: 1") != -1:
							foundSolutionFileName = re.search('Reference Submission: (.+?).cs', line)
							if foundSolutionFileName:
								solutionName = foundSolutionFileName.group(1)

							foundSubmissionFileName = re.search('Compared Submission: (.+?).cs', line)
							if foundSubmissionFileName:
								submissionName = foundSubmissionFileName.group(1)
							
							if not os.path.exists('Cluster' + solutionName):
   								os.makedirs('Cluster' + solutionName)
							
							if 'Sp18' not in solutionName:
								copy(solutionName + '.cs', 'Cluster' + solutionName)
								uniqueSubmissions.add(solutionName + '.cs')
							copy(submissionName + '.cs', 'Cluster' + solutionName)
							uniqueSubmissions.add(submissionName + '.cs')
							print ('Moved ' + solutionName + ' ' + submissionFile + ' to ' + solutionName + ' folder')
			if len(uniqueSubmissions) != 0:
				for fileToRemove in uniqueSubmissions:
					os.remove(fileToRemove) #Remove from the parent PSE folder (not the child clusters)

if __name__ == '__main__':
    main()