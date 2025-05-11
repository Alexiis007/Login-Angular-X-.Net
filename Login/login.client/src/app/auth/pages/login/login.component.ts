import { Component, inject, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);

  public myForm : FormGroup = this.fb.group({
    email:['',[Validators.required]],
    password:['',[Validators.required]]
  })

  public submit(){
    console.log(this.myForm.value.email);
  }
}
