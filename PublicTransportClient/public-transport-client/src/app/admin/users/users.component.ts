import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import User from 'src/app/models/User';
import { UserService } from 'src/app/services/user.service';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { container } from '@angular/core/src/render3';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  ngOnInit() {
    this.userService.getUsers().then(users => {
      this.users = users as User[]
    })
  }

  users: User[]
  selectedUser: User
  newUser: User = new User;
  passwordAgain: string
  step: number

  closeResult: string;

  constructor(private modalService: NgbModal, private userService: UserService) { }

  initial() {
    this.userService.getUsers().then(users => {
      this.users = users as User[]
    })
  }

  open(content) {
    this.newUser = new User
    this.passwordAgain = ''
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  openAddModal(content) {
    this.step = 1
    this.open(content)
  }

  openEditModal(id: number, content) {
    this.step = 2
    this.selectedUser = this.users.find(u => u.id == id)
    this.open(content)
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  addUser() {
    console.log(this.newUser)
  }

}
