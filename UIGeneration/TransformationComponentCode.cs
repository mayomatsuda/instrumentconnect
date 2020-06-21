
	private availableInputDevices: MIDIInputDevice[];
	private availableOutputDevices: MIDIOutputDevice[];
	
	constructor(private midiService: MIDIService) {
		this.subscriptions.push(this.midiService.availableInputDevicesSubject
			.subscribe(data => this.availableInputDevices = data));

		this.subscriptions.push(this.midiService.availableOutputDevicesSubject
			.subscribe(data => this.availableOutputDevices = data));
	}