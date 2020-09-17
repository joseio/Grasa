import io
import sys
import os
import re
from shutil import copy
import glob
import csv
import matplotlib.pyplot as plt; plt.rcdefaults()
import matplotlib.patches as mpatches
import numpy as np


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
					if PSE_Score == 'Passed&FailedTests' or PSE_Score == '1' or PSE_Score == 'NaN':
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

	#print(PSE_Score_list)
	#print(total_submission)
	
	#------- create x ticks for the graph--------
	PSE_score_x_tick = list()
	for x in PSE_Score_list:
		for a in x:
			if a in PSE_score_x_tick:
				continue
			else:
				PSE_score_x_tick.append(a)

	PSE_score_x_tick.sort()

	#--------- create y-values for the Graph (SUPER INEFFICIENT)------


	T1 = [0]*len(PSE_score_x_tick)
	T2 = [0]*len(PSE_score_x_tick)
	T3 = [0]*len(PSE_score_x_tick)
	T4 = [0]*len(PSE_score_x_tick)

	for submission in total_submission[0]:
		submission_index = total_submission[0].index(submission)
		score = PSE_Score_list[0][submission_index]
		x_tick_index = PSE_score_x_tick.index(score)		
		T1[x_tick_index] = submission
		total_submission[0][submission_index]= -1

	for submission in total_submission[1]:
		submission_index = total_submission[1].index(submission)
		score = PSE_Score_list[1][submission_index]
		x_tick_index = PSE_score_x_tick.index(score)		
		T2[x_tick_index] = submission
		total_submission[1][submission_index]= -1

	for submission in total_submission[2]:
		submission_index = total_submission[2].index(submission)
		score = PSE_Score_list[2][submission_index]
		x_tick_index = PSE_score_x_tick.index(score)		
		T3[x_tick_index] = submission
		total_submission[2][submission_index]= -1

	for submission in total_submission[3]:
		submission_index = total_submission[3].index(submission)
		score = PSE_Score_list[3][submission_index]
		x_tick_index = PSE_score_x_tick.index(score)		
		T4[x_tick_index] = submission
		total_submission[3][submission_index]= -1

	
#-------- DRAW GRAPH -----------------

	x = np.arange(len(T1))

	bar_width = 0.3
	plt.bar(x, T1, width = bar_width, color = 'blue', zorder=2)
	plt.bar(x+bar_width, T2, width = bar_width, color = 'orange', zorder=2)
	plt.bar(x+bar_width*2, T3, width = bar_width, color = 'green', zorder=2)
	plt.bar(x+bar_width*3, T4, width = bar_width, color = 'brown', zorder=2)

	plt.xticks(x+bar_width*2, PSE_score_x_tick)
	plt.title("Submission Chart of Multiple Problems")
	plt.xlabel("PSE SCORE")
	plt.ylabel("Submissions")

	blue_patch = mpatches.Patch(color ="blue", label='Sort')
	orange_patch = mpatches.Patch(color ="orange", label='AddToEnd')
	green_patch = mpatches.Patch(color ="green", label='LastTen')
	brown_patch = mpatches.Patch(color ="brown", label='isSorted')
	plt.legend(handles =[blue_patch, orange_patch, green_patch, brown_patch])

	# green_patch = mpatches.Patch(color ="green", label='AddToEnd')
	# red_patch = mpatches.Patch(color ="red", label='isSorted')
	# plt.legend(handles =[green_patch, red_patch])

	#plt.grid(axis = 'y')

	plt.show()




	# T1 = [0]*len(PSE_score_x_tick)
	# T2 = [0]*len(PSE_score_x_tick)
	# T3 = [0]*len(PSE_score_x_tick)
	# T4 = [0]*len(PSE_score_x_tick)

	# for submission in total_submission[0]:
	# 	submission_index = total_submission[0].index(submission)
	# 	score = PSE_Score_list[0][submission_index]
	# 	x_tick_index = PSE_score_x_tick.index(score)		
	# 	T1[x_tick_index] = submission
	# 	total_submission[0][submission_index]= -1

	# for submission in total_submission[1]:
	# 	submission_index = total_submission[1].index(submission)
	# 	score = PSE_Score_list[1][submission_index]
	# 	x_tick_index = PSE_score_x_tick.index(score)		
	# 	T2[x_tick_index] = submission
	# 	total_submission[1][submission_index]= -1

	# for submission in total_submission[2]:
	# 	submission_index = total_submission[2].index(submission)
	# 	score = PSE_Score_list[2][submission_index]
	# 	x_tick_index = PSE_score_x_tick.index(score)		
	# 	T3[x_tick_index] = submission
	# 	total_submission[2][submission_index]= -1

	# for submission in total_submission[3]:
	# 	submission_index = total_submission[3].index(submission)
	# 	score = PSE_Score_list[3][submission_index]
	# 	x_tick_index = PSE_score_x_tick.index(score)		
	# 	T4[x_tick_index] = submission
	# 	total_submission[3][submission_index]= -1

	
#-------- DRAW GRAPH -----------------

	# x = np.arange(len(T1))

	# bar_width = 0.15
	# plt.bar(x, T1, width = bar_width, color = 'green', zorder=2)
	# plt.bar(x+bar_width, T2, width = bar_width, color = 'red', zorder=2)
	# plt.bar(x+bar_width*2, T3, width = bar_width, color = 'orange', zorder=2)
	# plt.bar(x+bar_width*3, T4, width = bar_width, color = 'purple', zorder=2)

	# plt.xticks(x+bar_width*2, PSE_score_x_tick)
	# plt.title("Combined First Level Distribution")
	# plt.xlabel("PSE Score")
	# plt.ylabel("Number of Submissions")

	# green_patch = mpatches.Patch(color ="green", label='Sort')
	# red_patch = mpatches.Patch(color ="red", label='AddToEnd')
	# orange_patch = mpatches.Patch(color ="orange", label='LastTen')
	# purple_patch = mpatches.Patch(color ="purple", label='isSorted')
	# plt.legend(handles =[green_patch, red_patch, orange_patch, purple_patch])

	

	# plt.grid(axis = 'y')
	# plt.savefig(os.getcwd()+'\\Graphs\\FirstLevel\\Multi'+"_"+pexFilterMode+'.png')
	# plt.show()



if __name__ == '__main__':
	plotMultipleGraphs(sys.argv[1], sys.argv[2])