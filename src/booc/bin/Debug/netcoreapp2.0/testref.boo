import System.Text
import System.Reflection.Emit
#import Boo.Lang.Extensions		#BCE0010: 'Boo.Lang.Extensions.GetterAttribute' is an internal type. Ast attributes must be compiled to a separate assembly before they can be used.

class Test:
		
	[Getter(Str)]
	_str = GetStr()
	
	def GetStr():
		#return "中国你好吗?"
		sb = StringBuilder()
		sb.Append('你好')
		return sb.ToString() + PEFileKinds.ConsoleApplication.ToString()
