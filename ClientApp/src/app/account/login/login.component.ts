import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { AccountService } from "../account.service";
import { SharedService } from "src/app/shared/components/modals/shared.service";
import { take } from "rxjs";
import { User } from "src/app/shared/models/account/user.model";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup = new FormGroup({});
  submitted = false;
  errorMessages: string[] = [];
  returnUrl: string | null = null;
  constructor(
    private accountService: AccountService,
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.accountService.user$.pipe(take(1)).subscribe({
      next: (user: User | null) => {
        if (user) {
          this.router.navigateByUrl("/");
        } else {
          this.activatedRoute.queryParamMap.subscribe({
            next: (params: any) => {
              if (params) {
                this.returnUrl = params.get("returnUrl");
              }
            },
          });
        }
      },
    });
  }
  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.formBuilder.group({
      userName: ["", [Validators.required]],
      password: [
        "",
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
        ],
      ],
    });
  }

  login() {
    this.submitted = true;
    this.errorMessages = [];

    if (this.loginForm.valid) {
      // debugger;
      this.accountService.login(this.loginForm.value).subscribe({
        next: (response: any) => {
          // debugger;
          if (this.returnUrl) {
            this.router.navigateByUrl(this.returnUrl);
          } else {
            this.router.navigateByUrl("/");
          }
        },
        error: (error) => {
          // debugger;
          if (error.error.errors) {
            this.errorMessages = error.error.errors;
          } else if (error.error.value) {
            if (error.error.value.title == "error") {
              this.errorMessages.push(error.error.value.message);
            }
          } else if (error.error) {
            if (error.error.type === "error") {
              this.errorMessages.push("Please check your backend server");
            } else {
              this.errorMessages.push(error.error);
            }
          } else {
          }
        },
      });
    }
  }

  resendEmailConfirmationLink(){
    this.router.navigateByUrl('/account/send-email/resend-email-confirmation-link');
  }
}
