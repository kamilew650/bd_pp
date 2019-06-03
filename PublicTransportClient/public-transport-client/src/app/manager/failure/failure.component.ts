import { Component, OnInit } from '@angular/core';
import Failure from 'src/app/models/Failure';
import { FailureService } from 'src/app/services/failure.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-failure',
  templateUrl: './failure.component.html',
  styleUrls: ['./failure.component.css']
})
export class FailureComponent implements OnInit {

  constructor(private failureService: FailureService, private modalService: NgbModal) { }

  failures: Failure[]
  selectedFailure: Failure
  failureToEdit: Failure
  step: number

  ngOnInit() {
    this.failureService.get().then(failures => {
      console.log(failures)
      this.failures = failures as Failure[]
    })
  }

  initial() {
    this.failureService.get().then(failures => {
      console.log(failures)
      this.failures = failures as Failure[]
    })
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' })
  }

  openInfoModal(id: number, content) {
    this.step = 2
    this.selectedFailure = this.failures.find(u => u.id == id)
    this.open(content)
  }

  openEditModal(id: number, content) {
    this.step = 1
    this.failureToEdit = this.failures.find(u => u.id == id)
    this.selectedFailure = { ...this.failureToEdit }
    this.open(content)
  }

  editFailure() {
    this.failureService.update(this.selectedFailure.id, this.selectedFailure).then(res => {
      this.initial()
      this.modalService.dismissAll()
    })
  }

}
