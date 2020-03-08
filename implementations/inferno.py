# Import modules
import os
import json
import zipfile
import requests
import subprocess

# Load module
def load():
	arc = "Inferno.zip"
	url = "https://raw.githubusercontent.com/LimerBoy/Inferno/master/bin/" + arc
	tmp = os.environ["temp"] + "\\Inferno"
	if not os.path.exists(tmp):
		# Download core
		print("Downloading Inferno core...")
		with open(arc, "wb") as file:
			content = requests.get(url).content
			file.write(content)
		# Unzip archive to %temp%\Inferno
		print("Extracting to TEMP directory...")
		with zipfile.ZipFile(arc, "r") as archive:
			archive.extractall(tmp)
		# Remove
		print("Removing " + arc)
		os.remove(arc)

	# Return Inferno.exe location
	return tmp + "\\Inferno.exe"

# Execute command
def execute(command, arg1 = "", arg2 = "", arg3 = ""):
	core = load()
	# Start process
	process    = subprocess.Popen([core, command, arg1, arg2, arg3],
		stdin  = subprocess.PIPE,
		stdout = subprocess.PIPE,
		stderr = subprocess.PIPE
	)
	# Decode JSON
	output = json.loads(
		# Get output
		process.communicate()
		# Decode bytes
		[0].decode()
		)
	# If error - show message
	if output["error"]:
		print("ERROR: " + output["message"])
	# Return command output as JSON
	return output
