import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFBroker', defineAsyncComponent(() => import('@/views/forms/FormFBroker/QFormFBroker.vue')))
		app.component('QFormFCity', defineAsyncComponent(() => import('@/views/forms/FormFCity/QFormFCity.vue')))
		app.component('QFormFContact', defineAsyncComponent(() => import('@/views/forms/FormFContact/QFormFContact.vue')))
		app.component('QFormFCountry', defineAsyncComponent(() => import('@/views/forms/FormFCountry/QFormFCountry.vue')))
		app.component('QFormFPhotoAlbum', defineAsyncComponent(() => import('@/views/forms/FormFPhotoAlbum/QFormFPhotoAlbum.vue')))
		app.component('QFormFProperty', defineAsyncComponent(() => import('@/views/forms/FormFProperty/QFormFProperty.vue')))
	}
}
