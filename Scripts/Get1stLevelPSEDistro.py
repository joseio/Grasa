import io
import sys
import os
import re
from shutil import copy
import glob
import csv

def main():
	topDir = os.getcwd()
	allUniqueFiles = list()
	textForCsvFile = list()
	counter = 0
	for PSEScoreFolders in os.listdir(topDir):
		innerCounter = 0
		allUniqueFiles.clear()
		
		if  ".py" in PSEScoreFolders or ".csv" in PSEScoreFolders:
			continue
		else:
			print(os.getcwd() + " has: ")
			os.chdir(os.path.join(topDir, PSEScoreFolders))
			#insidePSEScoreFolder = os.getcwd()
			PSEScoreFolderString = str(PSEScoreFolders)
			for root, dirs, files in os.walk('.'):
				for file in files:
					if file.endswith(".cs"):
						innerCounter +=1
						allUniqueFiles.append(file.replace('.cs', ''))
						
			print(PSEScoreFolderString + ", " + str(innerCounter) )
			#print ("\n".join(allUniqueFiles))

			os.chdir(topDir)
			print (innerCounter)
			
			textForCsvFile.append([PSEScoreFolderString , str(innerCounter)])
			counter += innerCounter
			

	
	print (counter)
	
	for string in textForCsvFile:
		print(string[0] + ", " + string[1])
	

	print ("total num files: " + str(counter))
	#print(len(allUniqueFiles))
						

if __name__ == '__main__':
	main()