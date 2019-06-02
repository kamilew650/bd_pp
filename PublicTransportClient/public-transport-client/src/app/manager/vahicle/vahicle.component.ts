import { Component, OnInit } from '@angular/core';
import Vehicle from 'src/app/models/Vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-vahicle',
  templateUrl: './vahicle.component.html',
  styleUrls: ['./vahicle.component.css']
})
export class VehicleComponent implements OnInit {

  constructor(private vehicleService: VehicleService, private modalService: NgbModal) { }

  vehicles: Vehicle[]
  selectedVehicle: Vehicle
  newVehicle: Vehicle
  vehicleToEdit: Vehicle
  step: number

  ngOnInit() {
  }

  initial() {
    this.vehicleService.get().then(vehicles => {
      this.vehicles = vehicles as Vehicle[]
    })
  }

  open(content) {
    this.newVehicle = new Vehicle
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' })
  }

  openAddModal(content) {
    this.step = 1
    this.open(content)
  }

  openEditModal(id: number, content) {
    this.step = 2
    this.vehicleToEdit = this.vehicles.find(u => u.id == id)
    this.selectedVehicle = { ...this.vehicleToEdit }
    this.open(content)
  }

  deleteVehicle(id: number) {
    this.vehicleService.delete(id).then(res => {
      this.vehicles = this.vehicles.filter(u => u.id !== id)
    })
  }

  addVehicle() {
    this.vehicleService.add(this.newVehicle).then(res => {
      this.initial()
      this.modalService.dismissAll()
    })
  }

  editVehicle() {
    this.vehicleService.update(this.selectedVehicle.id, this.selectedVehicle).then(res => {
      this.initial()
      this.modalService.dismissAll()
    })
  }
}
