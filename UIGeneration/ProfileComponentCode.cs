
	private form: FormGroup;
	constructor(fb: FormBuilder) {
        this.form = fb.group({
            "name": this.currentProfile.name,
            "transformations": this.currentProfile.transformations
        });
    }