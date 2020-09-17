import os
import shutil

import errno
 
def copy(src, dest):
    try:
        shutil.copytree(src, dest)
    except OSError as e:
        # If the error was caused because the source wasn't a directory
        if e.errno == errno.ENOTDIR:
            shutil.copy(src, dest)
        else:
            print('Directory not copied. Error: %s' % e)

for studentDir in os.listdir():
	if '.py' in studentDir or '.jar' in studentDir or 'sharpened' in studentDir:
		continue
	os.system('java {} {} {}'.format('-jar', 'sharpen.jar', studentDir + '\\'))

	#Read and write to BinaryTree.cs
	with open(studentDir + '\\' + studentDir + '.net\\' + studentDir + '\\BinaryTree.cs', 'r+') as f:
		text = f.readlines()
		#Strip new lines
		text = [line.rstrip('\n') for line in text]
		for x in range(0, len(text)):
			#Does nothing if text to replace not found in curr string
			text[x] = text[x].replace('using Sharpen;', '')
			text[x] = text[x].replace('java.util.Random', 'Random')
			text[x] = text[x].replace('nextBoolean()', 'Next(2)==0')
		#Go back to beginning of file and overwrite
		f.seek(0)
		f.write('\n'.join(text))
		f.truncate()

	#Read and write to YourBinaryTree.cs
	with open(studentDir + '\\' + studentDir + '.net\\' + studentDir + '\\YourBinaryTree.cs', 'r+') as f:
		text = f.readlines()
		#Strip new lines
		text = [line.rstrip('\n') for line in text]
		for x in range(0, len(text)):
			#Does nothing if text to replace not found in curr string
			text[x] = text[x].replace('using Sharpen;', '')
		#Go back to beginning of file and overwrite
		f.seek(0)
		f.write('\n'.join(text))
		f.truncate()

	#Copy sharpened files
	copy(studentDir + '\\' + studentDir + '.net\\' + studentDir, 'sharpened\\' + studentDir)
