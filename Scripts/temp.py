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


def plotMultipleGraphs(location="", pexFilterMode=""):

	directory = os.getcwd()+location
	PSE_Score_list = list() #list of PSE score across all problems
	total_submission= list() # list of submission for each problem

	for folders in os.listdir(directory):
		sub_directory = directory+folders
		for sub_folders in os.listdir(sub_directory):
			if pexFilterMode == sub_folders:
				PSE_Score_directory = sub_directory+"\\"+sub_folders
				PSE_Score_smaller_list=list()
				file_submission=list()
				for PSE_Score in os.listdir(PSE_Score_directory):
					if PSE_Score == 'Passed&FailedTests':
						continue
					PSE_Score_smaller_list.append(PSE_Score)
					submission_folder = PSE_Score_directory+"\\"+PSE_Score
					filecount =0
					for files in os.listdir(submission_folder):
						if files.endswith(".cs"):
							filecount+=1
					file_submission.append(filecount)
					
					
				total_submission.append(file_submission)
				PSE_Score_list.append(PSE_Score_smaller_list)

	print(PSE_Score_list)
	print(total_submission)
			

	N = 4
	ind = np.arange(N)
	width = 0.27
	fig = plt.figure()
	ax = fig.add_subplot(111)


	val_one = PSE_Score_list[0]
	rects1 = ax.bar(ind, val_one, width, color='r')
	val_two = PSE_Score_list[1]
	rects2 = ax.bar(ind+width, val_two, width, color='g')
	val_three = PSE_Score_list[2]
	rects3 = ax.bar(ind+width*2, val_three, width, color='b')
	val_four = PSE_Score_list[3]
	rects4 = ax.bar(ind+width*2, val_four, width, color='y')

	ax.set_ylabel('Submissions')
	ax.set_xticks(ind+width)
	ax.legend( (rects1[0], rects2[0], rects3[0], reacts4[0]), ('Sort', 'AddToEnd', 'lastTen', 'isSorted'))
	#TO DO: 
	#ax.set_xtickelabels()
	
	autolabel(reacts1)
	autolabel(reacts2)
	autolabel(reacts3)
	autolabel(reacts4)
    

	def autolabel(rects):
		for rect in reacts:
			h = rect.get_height()
			ax.text(react.get_x()+react.get_width()/2., 1.05*h, '%d'%int(h), ha = 'center', va ='bottom')

    

	plt.show()


if __name__ == '__main__':
	plotMultipleGraphs(sys.argv[1], sys.argv[2])