import io
import sys
import os
import re
from shutil import copy
import glob
import csv
import matplotlib.pyplot as plt; plt.rcdefaults()
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.ticker as plticker
import matplotlib.patches as mpatches




def plotOneGraph(location="", problem="", pexFilterMode=""):
	directory = os.getcwd()+location + pexFilterMode
	PSE_Score = list()
	submissions = list()
	singleChildren = list()
	for parentClusters in os.listdir(directory):
		if parentClusters == 'Passed&FailedTests' or parentClusters == '1':
			continue
		PSE_Score.append(parentClusters)
		#print(parentClusters)
		innercounter = 0
		singleCount = 0
		myDir = os.path.join(directory, parentClusters)
		for childClusters in os.listdir(myDir):
			childClustersPath = os.path.join(myDir, childClusters)
			if os.path.isdir(childClustersPath):
				innercounter += 1
			elif ".cs" in childClusters: #If is single-child-cluster .cs file
				singleCount += 1

		submissions.append(innercounter)
		singleChildren.append(singleCount)

	# print(PSE_Score)
	# print(submissions)

	
	#Data for CompleteEquivalence, gotten from subtracting following PowerShell cmd results from total # files in first level, per problem:
		#dir -recurse |  ?{ $_.PSIsContainer } | %{ Write-Host $_.FullName (dir $_.FullName | Measure-Object).Count }
	#sortSingleClusters_Default = [0, 0, 1, 0, 1, 3, 0, 7, 3]
	#addToEndSingleClusters_Default = [10, 6, 5]
	#addToEndSingleClusters_Emission = [10, 6, 5]
	#lastTenSingleClusters_Default = []

	#------------------------------------------------------
	#VIJAY, SECTION TO EDIT:
		#Issue: This produces a graph of 3 colors, but we only want two colors


	bar_width = 0.6
	y_pos = np.arange(len(PSE_Score))
	plt.bar(y_pos, singleChildren, width = bar_width, align='center', color = 'orange', alpha =1)
	plt.bar(y_pos, submissions, width = bar_width, align='center', color = 'blue', alpha =1)
	plt.xticks(y_pos, PSE_Score)

	maxYVal = max(max(singleChildren), max(submissions))
	yTickFrequency = 1
	plt.yticks(np.arange(0, maxYVal+1, yTickFrequency))
	plt.xlabel("PSE Score")
	plt.ylabel('Number of Child Clusters')
	plt.title(problem+" ("+ pexFilterMode + "_NewEquivalence)")
	orange_patch = mpatches.Patch(color ="orange", alpha=1, label='Single-Child Clusters') 
	blue_patch = mpatches.Patch(color ="blue", alpha=1, label='Multi-Child Clusters')

	#-------------------------------------------------------------

	plt.legend(handles =[blue_patch, orange_patch])
	plt.show()

	# bar_width = 0.3
	# y_pos = np.arange(len(PSE_Score))
	# plt.barh(y_pos, singleChildren, height = bar_width, align='center', color = 'orange', alpha =1)
	# plt.barh(y_pos, submissions, height = bar_width, align='center', color = 'blue', alpha =1)
	# plt.yticks(y_pos, PSE_Score)

	# maxXVal = max(max(singleChildren), max(submissions))
	# xTickFrequency = 1 #or maxXVal//10
	# plt.xticks(np.arange(0, maxXVal+1, xTickFrequency)) #Change x tick frequency to 1
	# plt.ylabel("PSE Score")
	# plt.xlabel('Number of Child Clusters')
	# plt.title(problem+" ("+ pexFilterMode + ")")


	# orange_patch = mpatches.Patch(color ="orange", alpha=1, label='Single-Child Clusters') 
	# blue_patch = mpatches.Patch(color ="blue", alpha=1, label='Multi-Child Clusters')

	# #-------------------------------------------------------------

	# plt.legend(handles =[blue_patch, orange_patch])
	# plt.show()
	#print(os.getcwd())
	#plt.savefig(os.getcwd()+'\\Graphs\\SecondLevel\\NewEquivalence'+problem+"_"+pexFilterMode+'.png')


if __name__ == '__main__':
	plotOneGraph(sys.argv[1], sys.argv[2], sys.argv[3])
