<template>
	<teleport
		v-if="isReady"
		to="#q-modal-see-more-f-photo-album-properties-title-body">
		<q-row>
			<q-table
				v-bind="listCtrl"
				v-on="listCtrl.handlers">
				<template #header>
					<q-table-config
						:table-ctrl="listCtrl"
						v-on="listCtrl.handlers" />
				</template>
			</q-table>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed } from 'vue'
	import { mapActions } from 'pinia'
	import _merge from 'lodash-es/merge'

	import { useGenericDataStore } from '@quidgest/clientapp/stores'
	import { useNavDataStore } from '@quidgest/clientapp/stores'
	import VueNavigation from '@/mixins/vueNavigation.js'
	import ListHandlers from '@/mixins/listHandlers.js'
	import { navigationProperties } from '@/mixins/navHandlers.js'
	import { TableListControl } from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import hardcodedTexts from '@/hardcodedTexts.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'

	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { removeModal } from '@/utils/layout'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import ViewModelBase from '@/mixins/viewModelBase.js'

	const requiredTextResources = ['F_PHOTO_ALBUM__PROPERTIES__TITLE_SeeMore', 'hardcoded', 'messages']

	export default {
		name: 'FPhotoAlbumPropertiesTitleSeeMore',

		inheritAttrs: false,

		emits: [
			'close',
			'see-more-choice'
		],

		mixins: [
			navigationProperties,
			VueNavigation,
			ListHandlers
		],

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: String,

			/**
			 * The limits to which this "See more" control is subjected.
			 */
			limits: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The id of the current navigation.
			 */
			navigationId: {
				type: String,
				default: ''
			}
		},

		expose: [],

		data()
		{
			return {
				isReady: false,

				componentOnLoadProc: asyncProcM.getProcListMonitor('F_PHOTO_ALBUM__PROPERTIES__TITLE_SeeMore', false),

				interfaceMetadata: {
					id: 'F_PHOTO_ALBUM__PROPERTIES__TITLE_SeeMore', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'F_PHOTO_ALBUM__PROPERTIES__TITLE_SeeMore',
					name: 'F_PHOTO_ALBUM__PROPERTIES__TITLE_SeeMore',
					controller: 'PHOTO_ALBUM',
					action: 'F_PHOTO_ALBUM_PropertiesValTitle'
				},

				listCtrl: new TableListControl(this.getListConfig(), this),

				// Basic view model to handle access to GLOB, if necessary.
				model: new ViewModelBase(this),
			}
		},

		created()
		{
			this.componentOnLoadProc.addImmediateBusy(loadResources(this, requiredTextResources))

			this.listCtrl.init()
			this.onTableDBDataChanged()

			this.componentOnLoadProc.once(() => {
				this.isReady = true
				this.listCtrl.initData()
			}, this)
		},

		mounted()
		{
			// Listens for changes to the DB and updates the list accordingly.
			this.$eventHub.onMany(this.listCtrl.globalEvents, this.onTableDBDataChanged)

			const modalProps = {
				id: 'see-more-f-photo-album-properties-title',
				dismissAction: this.close,
				returnElement: 'F_PHOTO_ALBUM__PROPERTIES__TITLE_see-more_button'
			}
			const props = {
				class: 'q-dialog-see-more',
				title: computed(() => this.Resources.PROPERTIES34868),
				buttons: [
					{
						id: 'dialog-button-close',
						action: this.close,
						icon: { icon: 'cancel', type: 'svg' },
						props: {
							label: computed(() => this.Resources[hardcodedTexts.cancel]),
							variant: 'bold'
						}
					}
				]
			}
			this.setModal(props, modalProps)
		},

		beforeUnmount()
		{
			// Removes the listeners.
			this.$eventHub.offMany(this.listCtrl.globalEvents, this.onTableDBDataChanged)
			this.listCtrl.destroy()
			this.componentOnLoadProc.destroy()

			removeModal('see-more-f-photo-album-properties-title')
		},

		methods: {
			...mapActions(useGenericDataStore, [
				'setModal'
			]),

			...mapActions(useNavDataStore, [
				'setParamValue',
				'setEntryValue'
			]),

			close()
			{
				this.$emit('close')
			},

			onTableDBDataChanged()
			{
				// Wait for the computed properties of columns to finish resolving (e.g. "isVisible").
				setTimeout(() => {
					const params = {
						id: this.id || null,
						limits: this.limits,
						tableConfiguration: listFunctions.getTableConfiguration(this.listCtrl)
					}

					this.listCtrl.fetchListData(params)
				}, 0)
			},

			handleRowAction(eventData)
			{
				if (eventData.id === 'see-more-choice')
				{
					let rowKey = eventData?.rowKeyPath
					if (Array.isArray(eventData?.rowKeyPath) && eventData?.rowKeyPath.length > 0)
						rowKey = eventData?.rowKeyPath[eventData?.rowKeyPath.length - 1]

					this.$emit('see-more-choice', rowKey)
				}
				else
					this.onTableListExecuteAction(this.listCtrl, eventData)
			},

			getListConfig()
			{
				const vm = this
				const listProps = {
					configuration: {
						controller: 'PHOTO_ALBUM',
						action: 'F_photo_album_PropertiesValTitle',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTitle',
								area: 'PROPERTIES',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 50,
								scrollData: 50,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 2,
								name: 'ValPrice',
								area: 'PROPERTIES',
								field: 'PRICE',
								label: computed(() => this.Resources.PRICE06900),
								scrollData: 15,
								maxDigits: 10,
								decimalPlaces: 4,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'F_photo_album_PropertiesValTitle',
							serverMode: true,
							pkColumn: 'ValCodproperties_pk',
							tableAlias: 'PROPERTIES',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: '',
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'see-more-choice',
								name: 'see-more-choice',
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: 'ValTitle',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CITY', 'changed-BROKER', 'changed-PROPERTIES'],
						uuid: 'F_photo_album_F_photo_album_PropertiesValTitle',
						allSelectedRows: 'false',
						handlers: {
							rowAction: vm.handleRowAction
						},
						fixedControlLimits: vm.limits
					}
				}

				return listProps.configuration
			}
		}
	}
</script>
