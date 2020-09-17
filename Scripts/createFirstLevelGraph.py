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
import matplotlib.patches as mpatches




def plotOneGraph(location="", problem="", pexFilterMode=""):
	directory = os.getcwd()+location + "\\"+pexFilterMode
	#print(directory)
	PSE_Score = list()
	submissions = list()
	for folders in os.listdir(directory):
		#print(folders)
		if folders == 'Passed&FailedTests':
			continue
		PSE_Score.append(folders)
		#print(folders)
		innercounter = 0
		for files in os.listdir(os.path.join(directory, folders)):
			if files.endswith(".cs"):
				innercounter+=1
		submissions.append(innercounter)

	# print(PSE_Score)
	#print(submissions)
	total_submission = 0
	for i in submissions:
		total_submission+=i


	percentage = list()
	for i in submissions:
		j = (i/total_submission)*100
		percentage.append(j)

	
	bar_width = 0.6
	maxXVal = max(submissions)
	y_pos = np.arange(len(PSE_Score))
	#plt.bar(y_pos, percentage, width = 0.3, align = 'center', color = 'orange', alpha = 1)
	plt.bar(y_pos, submissions, width = bar_width, align = 'center', color = 'orange', alpha = 1)
	plt.xticks(y_pos, PSE_Score)
	plt.xticks(fontsize=8)
	plt.yticks(fontsize=8)
	xTickFrequency = 1
	plt.ylabel('Submissions')
	plt.xlabel('PSE Score')
	plt.title(problem)
	filter_patch = mpatches.Patch(alpha=1, color = 'orange', label= pexFilterMode)
	plt.legend(handles =[filter_patch])

	plt.show()
	#plt.savefig(os.getcwd()+'\\Graphs\\FirstLevel\\'+problem+"_"+pexFilterMode+'.png')


if __name__ == '__main__':
	plotOneGraph(sys.argv[1], sys.argv[2], sys.argv[3])
