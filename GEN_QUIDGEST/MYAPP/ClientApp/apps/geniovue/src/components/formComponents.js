import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormFAgent', defineAsyncComponent(() => import('@/views/forms/FormFAgent/QFormFAgent.vue')))
		app.component('QFormFProperty', defineAsyncComponent(() => import('@/views/forms/FormFProperty/QFormFProperty.vue')))
	}
}
