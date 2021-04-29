import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  ContactServiceProxy,
  ContactDto,
  ContactDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateContactDialogComponent } from './create-contact/create-contact-dialog.component';
import { EditContactDialogComponent } from './edit-contact/edit-contact-dialog.component';

class PagedContactsRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './contacts.component.html',
  animations: [appModuleAnimation()]
})
export class ContactsComponent extends PagedListingComponentBase<ContactDto> {
  contacts: ContactDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _contactsService: ContactServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedContactsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._contactsService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ContactDtoPagedResultDto) => {
        this.contacts = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(contact: ContactDto): void {
    abp.message.confirm(
      this.l('ContactDeleteWarningMessage', contact.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._contactsService
            .delete(contact.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createContact(): void {
    this.showCreateOrEditContactDialog();
  }

  editContact(contact: ContactDto): void {
    this.showCreateOrEditContactDialog(contact.id);
  }

  showCreateOrEditContactDialog(id?: number): void {
    let createOrEditContactDialog: BsModalRef;
    if (!id) {
      createOrEditContactDialog = this._modalService.show(
        CreateContactDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditContactDialog = this._modalService.show(
        EditContactDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditContactDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
