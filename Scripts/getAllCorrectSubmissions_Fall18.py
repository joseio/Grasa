import errno
import shutil
 
def copy(src, dest):
    try:
        shutil.copytree(src, dest)
    except OSError as e:
        # If the error was caused because the source wasn't a directory
        if e.errno == errno.ENOTDIR:
            shutil.copy(src, dest)
        else:
            print('Directory not copied. Error: %s' % e)

with open('2018_Fall_E2_120_3.txt') as f:
	firstArr = f.readlines()
#Remove '\n' from each line
firstArr = [x.strip() for x in firstArr]

with open('2018_Fall_E2_130_1.txt') as f:
	secondArr = f.readlines()
secondArr  = [x.strip() for x in secondArr]

for filename in firstArr:
	copy('CS125_Fall2018_StudentSubmissions/' + filename, \
		'Correct_Fall18_Submissions/2018_Fall_E2_120_3/' + filename)

for filename in secondArr:
	copy('CS125_Fall2018_StudentSubmissions/' + filename, \
		'Correct_Fall18_Submissions/2018_Fall_E2_130_1/' + filename)