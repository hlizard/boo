import System.Text
import System.Reflection.Emit

def GetStr():
	#return "中国你好吗?"
	sb = StringBuilder()
	sb.Append('你好')
	return sb.ToString() + PEFileKinds.ConsoleApplication.ToString()
