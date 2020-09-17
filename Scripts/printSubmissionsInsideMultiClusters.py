import io
import sys
import os
import re
from shutil import copy
import glob
import csv

def main():
	topDir = os.getcwd()
	counter = 0
	for PSEScoreFolders in os.listdir(topDir):
		
		if  not os.path.isdir(PSEScoreFolders):
			#Skip if not a folder
			continue 
		else:
			os.chdir(os.path.join(topDir, PSEScoreFolders))
			PSEScoreFolderPath = os.path.join(topDir, PSEScoreFolders)
			for childClusterDir in os.listdir(PSEScoreFolderPath):
				if not os.path.isdir(childClusterDir):
					continue
				else:
					for myFile in os.listdir(childClusterDir):
						if myFile.endswith(".cs"):
							print(myFile)
							with open(childClusterDir + ".txt", 'a') as text_file:
								#Append to text file
								text_file.write(myFile + '\n')
						
		os.chdir(topDir)

if __name__ == '__main__':
	main()