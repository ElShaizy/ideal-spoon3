import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/F_BROKER/:mode/:id?',
			name: 'form-F_BROKER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFBroker/QFormFBroker.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'BROKER',
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_CITY/:mode/:id?',
			name: 'form-F_CITY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFCity/QFormFCity.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CITY',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_CONTACT/:mode/:id?',
			name: 'form-F_CONTACT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFContact/QFormFContact.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CONTACT',
				humanKeyFields: [],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/F_COUNTRY/:mode/:id?',
			name: 'form-F_COUNTRY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFCountry/QFormFCountry.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'COUNTRY',
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_PROPERTY/:mode/:id?',
			name: 'form-F_PROPERTY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFProperty/QFormFProperty.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPERTIES',
				humanKeyFields: ['ValTitle', 'ValPrice'],
				isPopup: false
			}
		},
	]
}
