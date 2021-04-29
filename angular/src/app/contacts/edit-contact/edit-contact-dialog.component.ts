import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ContactServiceProxy,
  GetContactForEditOutput,
  ContactDto,
  ContactEditDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-contact-dialog.component.html'
})
export class EditContactDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  contact = new ContactEditDto();
  grantedPermissionNames: string[];
  checkedPermissionsMap: { [key: string]: boolean } = {};

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _contactService: ContactServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._contactService
      .getContactForEdit(this.id)
      .subscribe((result: GetContactForEditOutput) => {
        this.contact = result.contact;
       
      });
  }

  save(): void {
    this.saving = true;

    const contact = new ContactDto();
    contact.init(this.contact);

    this._contactService
      .update(contact)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
