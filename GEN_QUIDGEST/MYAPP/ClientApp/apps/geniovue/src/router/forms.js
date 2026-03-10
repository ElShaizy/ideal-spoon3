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
			path: '/:culture/:system/:module/form/F_PHOTO_ALBUM/:mode/:id?',
			name: 'form-F_PHOTO_ALBUM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFPhotoAlbum/QFormFPhotoAlbum.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PHOTO_ALBUM',
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
