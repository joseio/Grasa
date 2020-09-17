import os

	#Read and write to Partitioner.cs
for studentDir in os.listdir():
	if '.py' in studentDir:
		continue
	with open(studentDir + '\\BinaryTree.cs', 'r+') as f:
		text = f.readlines()
		#Strip new lines
		text = [line.rstrip('\n') for line in text]
		for x in range(0, len(text)):
			#Does nothing if text to replace not found in curr string
			text[x] = text[x].replace('System.Console.Out.', 'Console.')
		#Go back to beginning of file and overwrite
		f.seek(0)
		f.write('\n'.join(text))
		f.truncate()

	with open(studentDir + '\\YourBinaryTree.cs', 'r+') as f:
		text = f.readlines()
		#Strip new lines
		text = [line.rstrip('\n') for line in text]
		for x in range(0, len(text)):
			#Does nothing if text to replace not found in curr string
			text[x] = text[x].replace('System.Console.Out.', 'Console.')
		#Go back to beginning of file and overwrite
		f.seek(0)
		f.write('\n'.join(text))
		f.truncate()