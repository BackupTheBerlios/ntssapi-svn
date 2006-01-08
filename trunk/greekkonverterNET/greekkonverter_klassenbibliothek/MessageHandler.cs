namespace greekconverter
{
	using System;
	
	/// <summary> Class for maintaining error and debug messages using a message queue
	/// and a semaphore. Users can set and ask the message level, add a message
	/// to the queue, depending on either the message level or the state of the
	/// semaphore, print the content of the queue and clear the queue.
	/// <p>
	/// The steps of usage are:
	/// <ul>
	/// <li>create an instance: <code>MessageHandler mh = new MessageHandler();</code></li>
	/// <li>define a message level: <code>mh.setMsgLevel( MessageHandler.MSGLVL_STATUSMSG );</code></li>
	/// <li>let procedure C append a message: <code>mh.enqueueMsg( "Error xyz", MessageHandler.MSGLVL_ERRORMSG );</code></li>
	/// <li>let procedure B append a message, if the call to X did so: <code>mh.enqueueMsg( " at pos n" );</code></li>
	/// <li>let calling procedure A check the queue: <code>mh.checkMsgQueue( " in line m", null );</code></li>
	/// </ul>
	/// <p>
	/// Printing the queue also empties it. If you are not sure wether a calling procedure
	/// ever prints the queue, you can empty it calling <code>mh.clearMsgQueue();</code>.
	/// </summary>
	
	public class MessageHandler
	{
		/// <summary> Returns the current message level.
		/// *
		/// @ return the current message level
		/// </summary>
		/// <summary> Sets the message level to the specified value.
		/// *
		/// </summary>
		/// <param name="msgLevel">the new message level.
		/// </param>
		public static int MsgLevel
		{
			get
			{
				return msgLevel;
			}
			
			set
			{
				if (value < MSGLVL_NOMSG)
				{
					msgLevel = MSGLVL_NOMSG;
				}
				else if (value > MSGLVL_DEBUGMSG)
				{
					msgLevel = MSGLVL_DEBUGMSG;
				}
				else
				{
					msgLevel = value;
				}
			}
			
		}
		/// <summary> Tells if the message queue is emtpy.
		/// *
		/// </summary>
		/// <param name="true,">if the message queue is empty.
		/// </param>
		public static bool MsgQueueEmpty
		{
			get
			{
				return (msgQueue.Length == 0);
			}
			
		}
		/// <summary> The message levels are predefined as constants. A higher message level always
		/// includes messages from all lower message levels.
		/// </summary>
		public const int MSGLVL_NOMSG = 0; // no messages at all
		public const int MSGLVL_ERRORMSG = 10; // error messages only
		public const int MSGLVL_STATUSMSG = 20; // status information
		public const int MSGLVL_DEBUGMSG = 30; // messages only interesting for debugging
		// private:
		//UPGRADE_NOTE: Die Initialisierung von "msgLevel" wurde nach static method 'greekconverter.MessageHandler' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static int msgLevel;
		//UPGRADE_NOTE: Die Initialisierung von "msgQueue" wurde nach static method 'greekconverter.MessageHandler' verschoben. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static System.Text.StringBuilder msgQueue;
		private static bool msgSemaphore;
		
		public static System.String getClassInfo(int infoType)
		{
			System.String info;
			
			switch (infoType)
			{
				
				case 0:  info = "21-Mar-2002"; break;
				
				case 1:  info = "Contains methods for maintaining error and debug messages"; break;
				
				case 2:  info = "Michael Neuhold <michael.neuhold@aon.at>"; break;
				
				default:  info = "Brevis esse laboro, obscurus fio.";
					break;
				
			}
			return info;
		}
		
		/*
		Class was once not static, so it had two constructors.
		I left the code, maybe I'll change my mind some day...
		
		*
		* Alternative constructor initializes the class with the passed parameters.
		*
		* @param msgLevel the inital message level
		* @param bufSize  inital buffer size for class StringBuffer which holds the messages
		*
		public MessageHandler( int msgLevel, int bufSize )
		{
		setMsgLevel( msgLevel );
		msgQueue = new StringBuffer( bufSize );
		}
		
		
		*
		* The standard constructor initializes the message level with the most commonly
		* needed message level of MSGLVL_ERRORMSG and a string buffer size of 128.
		*
		public MessageHandler()
		{
		this( MSGLVL_ERRORMSG, 128 );
		}*/
		
		
		
		/// <summary> Appends a string to the message queue, if the current message level
		/// is greater than or equal to the message level of the message. An internal
		/// semaphore is set to signal that there is now a message in the queue.
		/// *
		/// </summary>
		/// <param name="msg">the message
		/// </param>
		/// <param name="msgLevel">the message level of the message
		/// </param>
		public static void  enqueueMsg(System.String msg, int msgLevel)
		{
			if (msgLevel <= MsgLevel)
			{
				msgQueue.Append(msg);
				msgSemaphore = true;
			}
		}
		
		/// <summary> Appends a string to the message queue, if the semaphore is currently
		/// set to true. The semaphore is then set to false.
		/// *
		/// </summary>
		/// <param name="msg">the message
		/// </param>
		public static void  enqueueMsg(System.String msg)
		{
			if (msgSemaphore)
			{
				msgQueue.Append(msg);
				msgSemaphore = false;
			}
		}
		
		/// <summary> Empties the message queue and sets the semaphore to false.
		/// </summary>
		public static void  clearMsgQueue()
		{
			msgQueue.Length = 0;
			msgSemaphore = false;
		}
		
		
		/// <summary> Prints the contents of the message queue to the error console
		/// and then empties the message queue and sets the semaphore to false.
		/// *
		/// </summary>
		/// <param name="infoHeader">additional information that is printed before the contents
		/// of the message queue
		/// </param>
		/// <param name="infoFooter">additional information that is printed after the contents
		/// of the message queue
		/// </param>
		public static void  printMsgQueue(System.String infoHeader, System.String infoFooter)
		{
			if (!MsgQueueEmpty)
			{
				if (infoHeader != null)
				{
					System.Console.Error.WriteLine(infoHeader);
				}
				System.Console.Error.WriteLine(msgQueue.ToString());
				if (infoFooter != null)
				{
					System.Console.Error.WriteLine(infoFooter);
				}
				clearMsgQueue();
			}
		}
		
		/// <summary> Returns a copy of the message queue string and clears the message queue
		/// itself. The semaphore is set to false. Useful if you want to display
		/// the message queue in an error message window instead of being listed
		/// at the console.
		/// </summary>
		public static System.String dequeueMsg()
		{
			System.String msgQueueCopy = new System.String(msgQueue.ToString().ToCharArray());
			clearMsgQueue();
			return msgQueueCopy;
		}
		static MessageHandler()
		{
			msgLevel = MSGLVL_ERRORMSG;
			msgQueue = new System.Text.StringBuilder(128);
		}
	}
}