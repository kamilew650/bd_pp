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
  userToEdit: User
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
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' })
  }

  openAddModal(content) {
    this.step = 1
    this.open(content)
  }

  openEditModal(id: number, content) {
    this.step = 2
    this.userToEdit = this.users.find(u => u.id == id)
    this.selectedUser = { ...this.userToEdit }
    this.open(content)
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id).then(res => {
      this.users = this.users.filter(u => u.id !== id)
    })
  }

  addUser() {
    this.userService.addUser(this.newUser).then(res => {
      this.initial()
      this.modalService.dismissAll()
    })
  }

  editUser() {
    this.userService.updateUser(this.selectedUser.id, this.selectedUser).then(res => {
      this.initial()
      this.modalService.dismissAll()
    })
  }

}
