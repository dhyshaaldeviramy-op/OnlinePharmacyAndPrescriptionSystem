import { Routes } from '@angular/router';
import { MedicineCatalog } from './features/admin/medicine-catalog/medicine-catalog/medicine-catalog';
import { MedicineSearch } from './features/customer/medicine-search/medicine-search';

export const routes: Routes = [
   // Default route
  {
    path: '',
    redirectTo: 'admin/medicines',
    pathMatch: 'full'
  },

  // ✅ Use Case 1 — Admin Catalog
  {
    path: 'admin/medicines',
    component: MedicineCatalog
  },

  // ✅ Use Case 2 — Customer Search
  {
    path: 'search',
    component: MedicineSearch
  },

  // ❌ Optional: handle invalid routes
  {
    path: '**',
    redirectTo: 'admin/medicines'
  }
];
