## CodeSimilarity


**Requirements:**

a)To run Tool

b)To run Scripts

1. python 2.7
2. pip
3. pip install mathplotlib


This is the most recent version of the CodeSimilartiy tool that is under current development. Improvements include better organization and easier to navigate directories.

---

**How to run experiments:**

1. Navigate to the "Driver" directory
2. Run "driver.py" with arguments using the following template:  
	a. python driver.py NameOfProblem ApproachType FilterType ClusterLevelToRun  	
	b. Ex. of running driver using Windows PowerShell:
 	```py .\driver.py Sp18_Q10_20_sort CompleteEquivalence EmissionFilter second```  
	c. Ex. of running driver using Mac & Linux terminals:
 	```python driver.py Sp18_Q10_20_sort CompleteEquivalence EmissionFilter second```  
	
3. Navigate to the "Results" directory to see the results of your experiments  
  
  
  
**How to run scripts:**

*createFirstLevelGraph.py:*  
1. Navigate to C://Users/...Path_way../codesimilarity/  
2. Sample Run:  python.exe .\Scripts\createFirstLevelGraph.py \Results\FirstLevel\Sp18_Q11_10_addToEnd\ "AddToEnd" "DefaultFilter"  	
	a. 1st arg: location of pse directories, 2nd arg: name of problem 3rd: Pex Filter Mode  
3. Saves '.png' file under folder named 'Graphs'

*plotMultipleGraph.py:*  
1. Navigate to C://Users/..Path_way../codesimilarity/  
2. Sample Run: python.exe .\Scripts\plotMultipleGraph.py \Results\FirstLevel\ "DefaultFilter"  
	a. 1st arg: location of the problem folders, 2nd argv: Pex Filter Mode
3. Saves '.png' file under folder name 'Graphs'

---

**Notes:**

*IF* you choose to circumvent the Python driver script by running the .sln in VS2010 directly, you **MUST** make sure to run *without* debgging.

*ApproachType-* Navigate to the "Approach" directory to view your list of possible approaches to choose from.  
*NameOfProblem-* Inside each approach, you'll find a list of problem names to choose from.  
*FilterType-* See notes section below.  
*ClusterLevelToRun-* Specifies which level you want to evaluate on--the first, secondm, or both. Your choices for this argument are:
	 ```first```,
	 ```second```,
	 ```both```  
  
The "DefaultFilter" in the "Approach" folder means that Pex was run with the Pex Emission filter *ON* (decreases the number of total Pex-reported tests), as shown below:
```
[PexMethod]
```
The "EmissionFilter" in the "Approach" folder means that Pex was run with the Pex Emission filter *OFF* (no limitations placed on the number of Pex-reported tests), as shown below:
```
[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
```  

If you encounter the "assembly reference not found" error in VS, you may need to manually copy the .dll file at "...Approach\problemName\editedMetaProject\bin\Debug\meta_project1525456207.dll" 
to "...Pex4Fun\problemName\behavioralsimilarity\Pex4Fun\Pex4Fun\bin\Debug"


How to display Pex code coverage in VS2010:
1. Right click 'Solution items' -> Add -> New Item
2. Select 'Test Settings' template -> Add
3. In pop-up window, hit 'Data and Diagnostics' -> Check the 'Code Coverage' box
4. Then double-click the 'Code Coverage' list item -> Check the meta_projectxxx.dll box -> OK -> Apply
5. Run Pex Explorations on method under test
6. When done, open resultant 'MetaProgram.g.cs' file in solution explorer pane
7. Right click the class name in code -> select 'Create Unit Tests' -> OK
8. Open MetaProgram.cs file in newly created sub-project
9. Right click class name -> 'Run tests'
10. When done, navigate to Test -> Windows -> Code Coverage Results
11. Examine results