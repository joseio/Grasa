import os
import sys
import subprocess
from shutil import copyfile

'''
Ex. of how to run driver in Windows:
 py .\driver.py Sp18_Q10_20_sort CompleteEquivalence EmissionFilter first   

Ex: of how to run on Mac & Linux:
 python driver.py Sp18_Q10_20_sort CompleteEquivalence EmissionFilter first   
'''

if len(sys.argv) == 5:
	problemName = sys.argv[1]
	approach = sys.argv[2]
	filterType = sys.argv[3]
	levelToRun = sys.argv[4]
elif len(sys.argv) == 4:
	problemName = sys.argv[1]
	filterType = sys.argv[2]
	levelToRun = sys.argv[3]

devenvPath =  'C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe'

if len(sys.argv) == 4:
	os.chdir('../Pex4Fun/' + problemName + '/behavioralsimilarity/Pex4Fun/Pex4Fun/bin/Debug')
	os.system('Pex4Fun.exe {} {} {}'.format(problemName, filterType, levelToRun))

if len(sys.argv) == 5:
	#Build meta_projectxyz.sln to produce .dll
	os.chdir('../Approach/' + approach + '/' + problemName + '/editedMetaProject')
	metaSlnPath = os.getcwd()
	subprocess.call([devenvPath, '/build', 'Debug', metaSlnPath+'\meta_project1525456207.sln']) 
	srcDll = metaSlnPath + '/bin/Debug/meta_project1525456207.dll'
	#To view build results, add the following 2 args to end of array:
		#subprocess.call([..., '/out', 'buildResults.txt'])

	#Build Pex4Fun.sln to produce .exe
	os.chdir('../../../../Pex4Fun/' + problemName + '/behavioralsimilarity/Pex4Fun')
	slnPath = os.getcwd()

	#Copy .dll over, creating subdirectory structure if doesn't already exist
	if not os.path.isdir(slnPath + '/Pex4Fun/bin/Debug'):
	   os.makedirs(slnPath + '/Pex4Fun/bin/Debug')
	dstDll = slnPath + '/Pex4Fun/bin/Debug/meta_project1525456207.dll'
	copyfile(srcDll, dstDll)

	subprocess.call([devenvPath, '/build', 'Debug', slnPath+'\Pex4Fun.sln'])

	#Run .exe
	os.chdir(slnPath + '/Pex4Fun/bin/Debug')
	os.system('Pex4Fun.exe {} {} {} {}'.format(problemName, approach, filterType, levelToRun))